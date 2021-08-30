using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.TodoLists.Commands.CreateTodoList
{
    /// <summary>
    /// Represents validator for <see cref="CreateTodoListCommand"/> command.
    /// </summary>
    public class CreateTodoListCommandValidator : AbstractValidator<CreateTodoListCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes new <see cref="CreateTodoListCommandValidator"/> entity.
        /// </summary>
        /// <param name="context">Application DB context.</param>
        public CreateTodoListCommandValidator(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required!")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters!")
                .MustAsync(BeUniqueTitle).WithMessage($"The specified title already exists!");
        }

        /// <summary>
        /// Defines rule, that new Title must be unique.
        /// </summary>
        /// <param name="title">TodoList title.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>True, if title is unique; otherwise, false.</returns>
        public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await _context.TodoLists.AllAsync(l => l.Title != title);
        }
    }
}