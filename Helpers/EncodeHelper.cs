using ModernSymmetricCiphers.Exceptions;
using ModernSymmetricCiphers.Models;
using System;
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
            var keys = KeyExpansion(secretKeyBytes, nr + 1);
            RoundKey();
        }

        private static byte[] KeyExpansion(byte[] initialKey, int roundCount)
        {
            var keys = new byte[roundCount + 1];

            for (var i = 0; i < roundCount; i++)
            {
                
            }

            return keys;
        }

        /// <summary>
        /// Дешифрует зашифрованный текст.
        /// </summary>
        /// <param name="encoder">Шифратор со всей информацией.</param>
        public static void Decode(this AesEncoder encoder)
        {

        }

        private static void RoundKey()
        {
            throw new NotImplementedException();
        }
    }
}