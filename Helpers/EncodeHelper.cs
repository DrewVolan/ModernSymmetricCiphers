using ModernSymmetricCiphers.Exceptions;
using ModernSymmetricCiphers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernSymmetricCiphers.Helpers
{
    /// <summary>
    /// Класс-помощник, обрабатывающий исходные данные шифратора.
    /// </summary>
    public static class EncodeHelper
    {
        /// <summary>
        /// Шифрует исходные данные.
        /// </summary>
        /// <param name="encoder">Шифратор со всей информацией.</param>
        public static void Encode(this AesEncoder encoder)
        {
            if (string.IsNullOrWhiteSpace(encoder.InitialText) || string.IsNullOrWhiteSpace(encoder.SecretKey))
            {
                throw new EncodeException("Исходный текст и секретный ключ не должны быть пустыми.");
            }

            var intBlockType = (int)encoder.BlockType;

            // Заполняем блоки.
            var initialText = encoder.InitialText;
            var initialTextBytes = Encoding.UTF8.GetBytes(initialText);
            var initialTextBlocksCount = initialTextBytes.Length % intBlockType != 0
                ? initialTextBytes.Length / intBlockType + 1
                : initialTextBytes.Length / intBlockType;
            var initialTextBlocks = new byte[initialTextBlocksCount][];
            for (var i = 0; i < initialTextBlocks.Length; i++)
            {
                initialTextBlocks[i] = initialTextBytes.Skip(i * intBlockType).Take(intBlockType).ToArray();
            }
            // Дополняем последний блок до нужного количества бит.
            var oldLastInitialTextBlockLength = initialTextBlocks.Last().Length;
            if (oldLastInitialTextBlockLength != intBlockType)
            {
                var newLastBlock = new byte[intBlockType];

                for (var i = 0; i < intBlockType; i++)
                {
                    newLastBlock[i] = i < oldLastInitialTextBlockLength
                        ? initialTextBlocks[initialTextBlocks.Length - 1][i]
                        : Convert.ToByte(0x00);
                }
                initialTextBlocks[initialTextBlocks.Length - 1] = newLastBlock;
            }

            var secretKey = encoder.SecretKey;
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            if (secretKeyBytes.Length > intBlockType)
            {
                throw new EncodeException($"Необходим ключ размером {intBlockType} байт или меньше.");
            }
            // Дополняем блок до нужного количества бит.
            var secretKeyBlockLength = secretKeyBytes.Length;
            if (secretKeyBlockLength != intBlockType)
            {
                var newBlock = new byte[intBlockType];

                for (var i = 0; i < intBlockType; i++)
                {
                    newBlock[i] = i < secretKeyBlockLength
                        ? secretKeyBytes[i]
                        : Convert.ToByte(0x00);
                }
                secretKeyBytes = newBlock;
            }

            // Определяем параметры.
            var nk = encoder.Nk; // Количество слов в ключе.
            var nr = encoder.Nr; // Количество раундов в алгоритме.

            // Получаем ключи для всех раундов.
            var keys = KeyExpansion(secretKeyBytes, nr + 1, nk);

            // Начинаем шифрование текста.
            for(var i = 0; i < initialTextBlocks.Length; i++)
            {
                AddRoundKey(ref initialTextBlocks[i], keys[0]); // "Нулевой" раунд.
                for (var j = 0; j < nr; j++)
                {
                    ByteSubstitution(ref initialTextBlocks[i]);
                    ShiftRow(ref initialTextBlocks[i]);
                    MixColumn(ref initialTextBlocks[i]);
                    AddRoundKey(ref initialTextBlocks[i], keys[j]);
                }
            }
        }

        private static void MixColumn(ref byte[] block)
        {
            var doubleBlock = GetDoubleBlock(block);

            var mcc = AesConstants.MixColumnsCoefficients;
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    doubleBlock[i][j] = (byte)((byte)(doubleBlock[0][j] * mcc[i][0]) ^ (byte)(doubleBlock[1][j] * mcc[i][1]) ^ (byte)(doubleBlock[2][j] * mcc[i][2]) ^ (byte)(doubleBlock[3][j] * mcc[i][3]));
                }
            }

            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    block[i * 4 + j] = doubleBlock[i][j];
                }
            }
        }

        private static void ShiftRow(ref byte[] block)
        {
            var doubleBlock = GetDoubleBlock(block);

            for (var i = 0; i < 4; i++)
            {
                var temp = doubleBlock[i][0];
                var temp1 = i == 0 ? temp : doubleBlock[i][(i - 1) % 4];
                var temp2 = i == 0 ? temp : doubleBlock[i][(i + 1) % 4];
                var temp3 = i == 0 ? temp : doubleBlock[i][(i + 2) % 4];
                var temp4 = i == 0 ? temp : doubleBlock[i][(i - 3) % 4];

                doubleBlock[i][0] = temp1;
                doubleBlock[i][1] = temp2;
                doubleBlock[i][2] = temp3;
                doubleBlock[i][3] = temp4;
            }
        }

        private static byte[][] GetDoubleBlock(byte[] block)
        {
            var doubleBlock = new byte[4][];
            for (var i = 0; i < 4; i++)
            {
                doubleBlock[i] = new byte[4];
                for (var j = 0; j < 4; j++)
                {
                    doubleBlock[i][j] = block[i * 4 + j];
                }
            }
            return doubleBlock;
        }

        private static byte[][][] KeyExpansion(byte[] initialKey, int roundCount, int wordCount)
        {
            var keys = new List<byte[][]>();

            var words = new byte[roundCount * wordCount + wordCount][];

            for (var i = 0; i < wordCount; i++)
            {
                words[i] = initialKey.Skip(wordCount * i).Take(wordCount).ToArray();
            }

            keys.Add(words.Take(wordCount).ToArray());
            var counterForKey = 0;
            for (var i = wordCount; i < roundCount * 4; i++)
            {
                if (i % wordCount == 0)
                {
                    words[i] = XorKeys(words[i - wordCount], G(words[i - 1], i / wordCount, wordCount));
                }
                else
                {
                    words[i] = XorKeys(words[i - wordCount], words[i - 1]);
                }

                counterForKey++;

                if (counterForKey == wordCount - 1)
                {
                    keys.Add(words.Skip(i - wordCount).Take(wordCount).ToArray());
                    counterForKey = 0;
                }
            }

            return keys.ToArray();
        }

        private static byte[] XorKeys(byte[] word1, byte[] word2)
        {
            var byteCount = word1.Length;
            var result = new byte[byteCount];

            for (var i = 0; i < byteCount; i++)
            {
                result[i] = (byte)(word1[i] ^ word2[i]);
            }

            return result;
        }

        private static byte[] G(byte[] word, int roundCount, int wordCount)
        {
            ShiftRowKey(ref word, wordCount);
            ByteSubstitution(ref word);
            AddRoundConstant(ref word, roundCount);
            return word;
        }

        private static void AddRoundConstant(ref byte[] word, int roundCount)
        {
            for (var i = 0; i < word.Length; i++)
            {
                word[i] = (byte)(word[i] ^ AesConstants.RoundConst[roundCount][i]);
            }
        }

        private static void ByteSubstitution(ref byte[] word)
        {
            for(var i = 0; i < word.Length; i++)
            {
                var hexByte = Convert.ToString(word[i], 16);
                var isBigByte = hexByte.Length == 2;
                var row = isBigByte
                    ? Convert.ToInt32(hexByte[0].ToString(), 16)
                    : 0;
                var column = isBigByte
                    ? Convert.ToInt32(hexByte[1].ToString(), 16)
                    : Convert.ToInt32(hexByte[0].ToString(), 16);

                word[i] = AesConstants.Sbox[row][column];
            }
        }

        private static void ShiftRowKey(ref byte[] word, int wordCount)
        {
            var temp = word[0];
            for (var i = 0; i < wordCount - 1; i++)
            {
                word[i] = word[i + 1];
            }
            word[wordCount - 1] = temp;
        }

        /// <summary>
        /// Дешифрует зашифрованный текст.
        /// </summary>
        /// <param name="encoder">Шифратор со всей информацией.</param>
        public static void Decode(this AesEncoder encoder)
        {

        }

        private static void AddRoundKey(ref byte[] block, byte[][] roundKey)
        {
            var keyList = new List<byte>();
            for (int i = 0; i < roundKey.Length; i++)
            {
                for (int j = 0; j < roundKey[i].Length; j++)
                {
                    keyList.Add(roundKey[i][j]);
                }
            }
            var key = keyList.ToArray();

            for (var i = 0; i < block.Length; i++)
            {
                block[i] = (byte)(block[i] ^ key[i]);
            }
        }
    }
}