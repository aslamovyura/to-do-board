using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.CQRS.TodoItems.Commands.UpdateTodoItemDetails
{
    /// <summary>
    /// Defines command to update items details.
    /// </summary>
    public class UpdateTodoItemDetailCommand : IRequest
    {
        /// <summary>
        /// TodoItem ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// TodoList ID.
        /// </summary>
        public int ListId { get; set; }

        /// <summary>
        /// Item priority level.
        /// </summary>
        public PriorityLevel Priority { get; set; }

        /// <summary>
        /// Item Note.
        /// </summary>
        public string Note { get; set; }
    }

    /// <summary>
    /// Defines handler for command to update TodoItem details.
    /// </summary>
    public class UpdateTodoItemDetailCommandHandler : IRequestHandler<UpdateTodoItemDetailCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes hadler for <see cref="UpdateTodoItemDetailCommand"/> command.
        /// </summary>
        /// <param name="context"></param>
        public UpdateTodoItemDetailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles <see cref="UpdateTodoItemDetailCommand"/> command.
        /// </summary>
        /// <param name="request">Incoming request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Awaitable task.</returns>
        public async Task<Unit> Handle(UpdateTodoItemDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            entity.ListId = request.ListId;
            entity.Priority = request.Priority;
            entity.Note = request.Note;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}