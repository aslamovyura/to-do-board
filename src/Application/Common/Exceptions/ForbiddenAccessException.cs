using System;
namespace Application.Common.Exceptions
{
    /// <summary>
    /// Defines exception for forbiddent access.
    /// </summary>
    public class ForbiddenAccessException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ForbiddenAccessException"/> 
        /// </summary>
        public ForbiddenAccessException() : base() { }
    }
}