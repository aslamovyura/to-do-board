using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Events;
using MediatR;

namespace Application.CQRS.TodoItems.Commands.CreateTodoItem
{
    /// <summary>
    /// Command to create new TodoItem.
    /// </summary>
    public class CreateTodoItemCommand : IRequest<int>
    {
        /// <summary>
        /// TodoList ID.
        /// </summary>
        public int ListId { get; set; }

        /// <summary>
        /// Item title.
        /// </summary>
        public string Title { get; set; }
    }

    /// <summary>
    /// Handler of the command to create new TodoItem.
    /// </summary>
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Define new <see cref="CreateTodoItemCommandHandler"/> object.
        /// </summary>
        /// <param name="context">Application DB context.</param>
        public CreateTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Handle command to create new TodoItem.
        /// </summary>
        /// <param name="request">Request to create new TodoItem.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>New entity ID.</returns>
        public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoItem
            {
                ListId = request.ListId,
                Title = request.Title,
                Done = false
            };

            entity.DomainEvents.Add(new TodoItemCreatedEvent(entity));

            _context.TodoItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}