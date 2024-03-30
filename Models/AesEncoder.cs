using ModernSymmetricCiphers.Enums;

namespace ModernSymmetricCiphers.Models
{
    /// <summary>
    /// Класс, содержащий информацию о шифровании.
    /// </summary>
    public class AesEncoder
    {
        private byte[] initialBytes;
        private string secretKey;
        private byte[] finishedBytes;
        private BlockEnum blockType;

        /// <summary>
        /// Исходный текст.
        /// </summary>
        public byte[] InitialBytes
        {
            get
            {
                return initialBytes;
            }
            set
            {
                initialBytes = value;
            }
        }

        /// <summary>
        /// Секретный ключ.
        /// </summary>
        public string SecretKey
        {
            get
            {
                return secretKey;
            }
            set
            {
                secretKey = value;
            }
        }

        /// <summary>
        /// Результат шифрования.
        /// </summary>
        public byte[] FinishedBytes
        {
            get
            {
                return finishedBytes;
            }
            set
            {
                finishedBytes = value;
            }
        }

        public BlockEnum BlockType
        {
            get
            {
                return blockType;
            }
            set
            {
                blockType = value;
            }
        }

        /// <summary>
        /// Количество слов в ключе.
        /// </summary>
        public int Nk => (int)BlockType * 8 / 32;

        /// <summary>
        /// Количество раундов в алгоритме.
        /// </summary>
        public int Nr => Nk + 6;
    }
}