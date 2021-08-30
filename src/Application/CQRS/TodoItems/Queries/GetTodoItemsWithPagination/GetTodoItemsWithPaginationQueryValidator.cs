using FluentValidation;

namespace Application.CQRS.TodoItems.Queries.GetTodoItemsWithPagination
{
    /// <summary>
    /// Represents validator for <see cref="GetTodoItemsWithPaginationQuery"/> entity.
    /// </summary>
    public class GetTodoItemsWithPaginationQueryValidator : AbstractValidator<GetTodoItemsWithPaginationQuery>
    {
        /// <summary>
        /// Represents validator for <see cref="GetTodoItemsWithPaginationQuery"/> entity.
        /// </summary>
        public GetTodoItemsWithPaginationQueryValidator()
        {
            RuleFor(x => x.ListId).NotEmpty().WithMessage("ListId is required!");
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1).WithMessage("PageNumber must be at least greater than or equal to 1!");
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1).WithMessage("PageSize must be at least greater than or equal to 1!");
        }
    }
}