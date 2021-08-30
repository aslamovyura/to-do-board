using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.CQRS.TodoLists.Commands.UpdateTodoList
{
    /// <summary>
    /// Defines command to update entity.
    /// </summary>
    public class UpdateTodoListCommand : IRequest
    {
        /// <summary>
        /// TodoList ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// TodoList title.
        /// </summary>
        public string Title { get; set; }
    }

    /// <summary>
    /// Defines handler for command to update TodoList.
    /// </summary>
    public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes <see cref="UpdateTodoListCommandHandler"/> entity.
        /// </summary>
        /// <param name="context"></param>
        public UpdateTodoListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles <see cref="UpdateTodoListCommand"/> command.
        /// </summary>
        /// <param name="request">Incoming request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Awaitable task.</returns>
        public async Task<Unit> Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoLists.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoList), request.Id);
            }

            entity.Title = request.Title;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}