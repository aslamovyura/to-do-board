using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.TodoLists.Commands.DeleteTodoList
{
    /// <summary>
    /// Defines command to delete TodoList.
    /// </summary>
    public class DeleteTodoListCommand : IRequest
    {
        public int Id { get; set; }
    }

    /// <summary>
    /// Defines handler for command to delete TodoList.
    /// </summary>
    public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand>
    {
        private readonly IApplicationDbContext _context;


        public DeleteTodoListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Defines handler for <see cref="DeleteTodoListCommand"/> command.
        /// </summary>
        /// <param name="request">Incoming request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Awaitable task.</returns>
        public async Task<Unit> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoLists
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoList), request.Id);
            }

            _context.TodoLists.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}