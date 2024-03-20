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

            var initialText = encoder.InitialText;
            var initialTextBytes = Encoding.UTF8.GetBytes(initialText);

            var blocksCount = initialTextBytes.Length % (int)encoder.BlockType != 0
                ? initialTextBytes.Length / intBlockType + 1
                : initialTextBytes.Length / intBlockType;

            var initialTextBlocks = new byte[blocksCount][];

            for (var i = 0; i < initialTextBlocks.Length; i++)
            {
                initialTextBlocks[i] = initialTextBytes.Skip(i * intBlockType).Take(intBlockType).ToArray();
            }

            var secretKey = encoder.SecretKey;
            var secretKeyBytes = new byte[secretKey.Length];
            for (var i = 0; i < secretKey.Length; i++)
            {
                secretKeyBytes[i] = Convert.ToByte(secretKey[i]);
            }
        }

        /// <summary>
        /// Дешифрует зашифрованный текст.
        /// </summary>
        /// <param name="encoder">Шифратор со всей информацией.</param>
        public static void Decode(this AesEncoder encoder)
        {

        }
    }
}