using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities;

namespace Application.CQRS.TodoLists.Queries.GetTodos
{
    /// <summary>
    /// Defines DTO for 
    /// </summary>
    public class TodoItemDto : IMapFrom<TodoItem>
    {
        /// <summary>
        /// Item ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID of TodoList.
        /// </summary>
        public int ListId { get; set; }

        /// <summary>
        /// Item title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Check item competion.
        /// </summary>
        public bool Done { get; set; }

        /// <summary>
        /// Item priority.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Priority level Note.
        /// </summary>
        public string Note { get; set; }

        /// <inheritdoc/>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoItem, TodoItemDto>()
                   .ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority));
        }
    }
}