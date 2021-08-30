using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.TodoLists.Queries.GetTodos
{
    /// <summary>
    /// Defines Todo items query.
    /// </summary>
    public class GetTodosQuery : IRequest<TodosVm>
    { }

    /// <summary>
    /// Defines hadler for Todo items query.
    /// </summary>
    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, TodosVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes handler for Todo items query.
        /// </summary>
        /// <param name="context">Application DB context.</param>
        /// <param name="mapper">Mapping service.</param>
        public GetTodosQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Hadles request for Todo items.
        /// </summary>
        /// <param name="request">Incoming request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        public async Task<TodosVm> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            return new TodosVm
            {
                PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                    .Cast<PriorityLevel>()
                    .Select(p => new PriorityLevelDto { Value = (int)p, Name = p.ToString() })
                    .ToList(),

                Lists = await _context.TodoLists
                    .AsNoTracking()
                    .ProjectTo<TodoListDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Title)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}