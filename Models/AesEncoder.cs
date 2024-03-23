using ModernSymmetricCiphers.Enums;

namespace ModernSymmetricCiphers.Models
{
    /// <summary>
    /// Класс, содержащий информацию о шифровании.
    /// </summary>
    public class AesEncoder
    {
        private string initialText;
        private string secretKey;
        private string finishedText;
        private BlockEnum blockType;

        /// <summary>
        /// Исходный текст.
        /// </summary>
        public string InitialText
        {
            get
            {
                return initialText;
            }
            set
            {
                initialText = value;
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
        public string FinishedText
        {
            get
            {
                return finishedText;
            }
            set
            {
                finishedText = value;
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