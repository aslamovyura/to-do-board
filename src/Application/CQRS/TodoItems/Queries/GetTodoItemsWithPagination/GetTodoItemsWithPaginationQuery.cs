using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Mapping;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Application.CQRS.TodoItems.Queries.GetTodoItemsWithPagination
{
    /// <summary>
    /// Query to get TodoItems as paginated list of brief DTO.
    /// </summary>
    public class GetTodoItemsWithPaginationQuery : IRequest<PaginatedList<TodoItemBriefDto>>
    {
        /// <summary>
        /// List ID to get items from.
        /// </summary>
        public int ListId { get; set; }

        /// <summary>
        /// Number of page to represent entities. 
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Size of page to represent entities.
        /// </summary>
        public int PageSize { get; set; } = 10;
    }

    /// <summary>
    /// Represents handler for TodoItems query.
    /// </summary>
    public class GetTodoItemsWithPaginationQueryHandler : IRequestHandler<GetTodoItemsWithPaginationQuery, PaginatedList<TodoItemBriefDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Defines handler for TodoItems query.
        /// </summary>
        /// <param name="context">Application DB context.</param>
        /// <param name="mapper">Mapping service.</param>
        public GetTodoItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Handle TodoItems query.
        /// </summary>
        /// <param name="request">Request for TodoItems query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>TodoItems dto as a paginated list.</returns>
        public async Task<PaginatedList<TodoItemBriefDto>> Handle(GetTodoItemsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            return await _context.TodoItems
                .Where(t => t.ListId == request.ListId)
                .OrderBy(t => t.Title)
                .ProjectTo<TodoItemBriefDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}