using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Application.Common.Mapping
{
    /// <summary>
    /// Profile for entities with mapping scheme.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Define mapping profiles for assembly entities.
        /// </summary>
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces()
                             .Any(i => i.IsGenericType && i.GetGenericTypeDefinition().Equals(typeof(IMapFrom<>))))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping")
                        ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");

                methodInfo.Invoke(instance, new object[] { this });
            }
        }
    }
}