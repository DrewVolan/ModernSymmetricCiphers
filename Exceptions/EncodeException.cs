using System;
using System.Runtime.Serialization;

namespace ModernSymmetricCiphers.Exceptions
{
    /// <summary>
    /// Ошибка шифрования.
    /// </summary>
    [Serializable]
    public class EncodeException : Exception
    {
        public EncodeException() { }

        public EncodeException(string message) : base(message) { }

        public EncodeException(string message, Exception innerException) : base(message, innerException) { }

        protected EncodeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}