using System.Collections.Generic;

namespace Application.CQRS.TodoLists.Queries.GetTodos
{
    /// <summary>
    /// TodoVM DTO.
    /// </summary>
    public class TodosVm
    {
        /// <summary>
        /// Array of priority levels.
        /// </summary>
        public ICollection<PriorityLevelDto> PriorityLevels { get; set; }

        /// <summary>
        /// Array of DTO lists.
        /// </summary>
        public ICollection<TodoListDto> Lists { get; set; }
    }
}