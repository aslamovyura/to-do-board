using System.Collections.Generic;
using Application.Common.Mapping;
using Domain.Entities;

namespace Application.CQRS.TodoLists.Queries.GetTodos
{
    /// <summary>
    /// Defines DTO for <see cref="TodoList"/> entities.
    /// </summary>
    public class TodoListDto : IMapFrom<TodoList>
    {
        /// <summary>
        /// Initializes <see cref="TodoListDto"/> entity.
        /// </summary>
        public TodoListDto()
        {
            Items = new List<TodoItemDto>();
        }

        /// <summary>
        /// TodoList ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// TodoList Title.
        /// </summary>
        public string Title { get; set; }

        //public string Colour { get; set; }

        /// <summary>
        /// Items belonging to current list.
        /// </summary>
        public ICollection<TodoItemDto> Items { get; set; }
    }
}