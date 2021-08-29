using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Mapping
{
    /// <summary>
    /// Represents extensions methods to map entities.
    /// </summary>
    public static class MappingExtensions
    {
        /// <summary>
        /// Convert query of entities to paginated list format.
        /// </summary>
        /// <typeparam name="TDestination">Entity type.</typeparam>
        /// <param name="queryable">Entities query.</param>
        /// <param name="pageNumber">Current page number.</param>
        /// <param name="pageSize">Page size.</param>
        /// <returns>Paged list of entities.</returns>
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
        {
            return PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, pageSize);
        }

        /// <summary>
        /// Projects query of entities to the List format.
        /// </summary>
        /// <typeparam name="TDestination">Entity type.</typeparam>
        /// <param name="queryable">Entities query.</param>
        /// <param name="configuration">Mapping configuration.</param>
        /// <returns>List of entities.</returns>
        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration)
        {
            return queryable.ProjectTo<TDestination>(configuration).ToListAsync();
        }
    }
}