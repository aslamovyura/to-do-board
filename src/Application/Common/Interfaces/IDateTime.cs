using System;
namespace Application.Common.Interfaces
{
    /// <summary>
    /// Interface for entities, containing Date/Time.
    /// </summary>
    public interface IDateTime
    {
        /// <summary>
        /// Current Data and Time.
        /// </summary>
        DateTime Now { get; set; }
    }
}