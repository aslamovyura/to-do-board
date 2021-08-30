using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.CQRS.TodoItems.Commands.DeleteTodoItem
{
    /// <summary>
    /// Define command to delete TodoItem with specified ID.
    /// </summary>
    public class DeleteTodoItemCommand : IRequest
    {
        /// <summary>
        /// TodoItem ID.
        /// </summary>
        public int Id { get; set; }
    }

    // <summary>
    /// Represents handler of the command to delete TodoItem entity with specified ID.
    /// </summary>
    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Define command to delete TodoItem entity.
        /// </summary>
        /// <param name="context">Application DB context.</param>
        public DeleteTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Handle request to delete specified TodoItem.
        /// </summary>
        /// <param name="request">Request to delete new TodoItem.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var entity = await _context.TodoItems.FindAsync(request.Id);

            if (entity is null) throw new NotFoundException(nameof(TodoItem), request.Id);

            _context.TodoItems.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}