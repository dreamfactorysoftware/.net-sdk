namespace DreamFactory
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// DreamFactoryException.
    /// </summary>
    [Serializable]
    public class DreamFactoryException : Exception
    {
        /// <inheritdoc />
        public DreamFactoryException(string message) : base(message)
        {
        }

        /// <inheritdoc />
        public DreamFactoryException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <inheritdoc />
        protected DreamFactoryException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}