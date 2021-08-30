using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.TodoLists.Commands.UpdateTodoList
{
    /// <summary>
    /// Defines validator for <see cref="UpdateTodoListCommand"/> entity.
    /// </summary>
    public class UpdateTodoListCommandValidator : AbstractValidator<UpdateTodoListCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes new <see cref="UpdateTodoListCommandValidator"/> entity.
        /// </summary>
        /// <param name="context">Application DB context.</param>
        public UpdateTodoListCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
                .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
        }

        // <summary>
        /// Defines rule, that new Title must be unique.
        /// </summary>
        /// <param name="title">TodoList title.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>True, if title is unique; otherwise, false.</returns>
        public async Task<bool> BeUniqueTitle(UpdateTodoListCommand model, string title, CancellationToken cancellationToken)
        {
            return await _context.TodoLists
                .Where(l => l.Id != model.Id)
                .AllAsync(l => l.Title != title);
        }
    }
}