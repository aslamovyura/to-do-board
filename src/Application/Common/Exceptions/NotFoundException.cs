using System;
namespace Application.Common.Exceptions
{
    /// <summary>
    /// Represents errors that occur during application execution when some entities was not found.
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Define <see cref="NotFoundException"/> object, when some entities were not found.
        /// </summary>
        public NotFoundException()
            : base() { }

        /// <summary>
        /// Define <see cref="NotFoundException"/> object, when some entities were not found.
        /// </summary>
        /// <param name="message"></param>
        public NotFoundException(string message)
            : base(message) { }

        /// <summary>
        /// Define <see cref="NotFoundException"/> object, when some entities were not found.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Exception object with error details.</param>
        public NotFoundException(string message, Exception innerException)
            : base(message, innerException) { }

        /// <summary>
        /// Define <see cref="NotFoundException"/> object, when entities were not found.
        /// </summary>
        /// <param name="name">Entity name.</param>
        /// <param name="property">Entity property, that not found.</param>
        public NotFoundException(string name, object property)
            : base($"Entity \"{name}\" ({property}) was not found.") { }
    }
}