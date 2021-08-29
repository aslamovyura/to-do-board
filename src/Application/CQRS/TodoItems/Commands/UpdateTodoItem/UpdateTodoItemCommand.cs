using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Domain.Entities;
using Domain.Events;
using MediatR;

namespace Application.CQRS.TodoItems.Commands.CreateTodoItem
{
    /// <summary>
    /// Command to update TodoItem.
    /// </summary>
    public class UpdateTodoItemCommand : IRequest
    {
        /// <summary>
        /// ID of item to update.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Item title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// TodoItem status.
        /// </summary>
        public bool Done { get; set; }
    }

    /// <summary>
    /// Handler of the command to create new TodoItem.
    /// </summary>
    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Define new <see cref="UpdateTodoItemCommandHandler"/> object.
        /// </summary>
        /// <param name="context">Application DB context.</param>
        public UpdateTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Handle command to create new TodoItem.
        /// </summary>
        /// <param name="request">Request to create new TodoItem.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>New entity ID.</returns>
        public async Task<Unit> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var entity = await _context.TodoItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            entity.Title = request.Title;
            entity.Done = request.Done;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}