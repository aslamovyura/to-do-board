using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.CQRS.TodoLists.Commands.CreateTodoList
{
    /// <summary>
    /// Defines command to create new TodoList.
    /// </summary>
    public class CreateTodoListCommand : IRequest<int>
    {
        /// <summary>
        /// TodoList title.
        /// </summary>
        public string Title { get; set; }
    }

    /// <summary>
    /// Defines handler for Create TodoList command.
    /// </summary>
    public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, int>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Defines <see cref="CreateTodoListCommandHandler"/> entity.
        /// </summary>
        /// <param name="context">Application DB context.</param>
        public CreateTodoListCommandHandler(IApplicationDbContext context)
        {
            _context = _context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Handle command to create new TodoList entity.
        /// </summary>
        /// <param name="request">Incoming request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>New entity ID.</returns>
        public async Task<int> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            var entity = new TodoList
            {
                Title = request.Title
            };

            _context.TodoLists.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}