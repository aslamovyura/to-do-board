using Application.Common.Mapping;
using Domain.Entities;

namespace Application.CQRS.TodoItems.Queries.GetTodoItemsWithPagination
{
    /// <summary>
    /// Represents brief DTO of TodoItem.
    /// </summary>
    public class TodoItemBriefDto : IMapFrom<TodoItem>
    {
        /// <summary>
        /// Item ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Items list ID.
        /// </summary>
        public int ListId { get; set; }

        /// <summary>
        /// Item title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Item completion status.
        /// </summary>
        public bool Done { get; set; }
    }
}