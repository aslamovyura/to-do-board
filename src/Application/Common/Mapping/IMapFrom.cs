using AutoMapper;

namespace Application.Common.Mapping
{
    /// <summary>
    /// Defines an interface for mapping entities.
    /// </summary>
    /// <typeparam name="T">Type of mapping entity.</typeparam>
    public interface IMapFrom<T>
    {
        /// <summary>
        /// Defines how the mapping should be performed.
        /// </summary>
        /// <param name="profile">Mapping profile.</param>
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}