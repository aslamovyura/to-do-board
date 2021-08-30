using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Security;
using MediatR;

namespace Application.CQRS.TodoLists.Commands.PurgeTodoList
{
    /// <summary>
    /// Defines command to purge items from TodoList.
    /// </summary>
    [Authorize(Roles = "Administrator")]
    [Authorize(Policy = "CanPurge")]
    public class PurgeTodoListsCommand : IRequest
    { }

    /// <summary>
    /// Defines handler for <see cref="PurgeTodoListsCommand"/> command.
    /// </summary>
    public class PurgeTodoListsCommandHandler : IRequestHandler<PurgeTodoListsCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes <see cref="PurgeTodoListsCommandHandler"/> entity.
        /// </summary>
        /// <param name="context"></param>
        public PurgeTodoListsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles command to purge items from TodoList.
        /// </summary>
        /// <param name="request">Incoming request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Awaitable task.</returns>
        public async Task<Unit> Handle(PurgeTodoListsCommand request, CancellationToken cancellationToken)
        {
            _context.TodoLists.RemoveRange(_context.TodoLists);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}