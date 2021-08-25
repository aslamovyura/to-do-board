using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.Enums;
using Domain.Events;
using Domain.Interfaces;

namespace Domain.Entities
{
    /// <summary>
    /// To-Do Item Entity.
    /// </summary>
    public class TodoItem : AuditableEntity, IHasDomainEvent
    {
        private bool _done;

        /// <summary>
        /// Item Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id of To-Do List.
        /// </summary>
        public int ListId { get; set; }

        /// <summary>
        /// Item title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Item note.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Item priority level.
        /// </summary>
        public PriorityLevel Priority { get; set; }

        /// <summary>
        /// Date to remind user.
        /// </summary>
        public DateTime? Reminder { get; set; }

        /// <summary>
        /// Check whether Item is Done.
        /// </summary>
        public bool Done
        {
            get => _done;
            set
            {
                if (value == true && _done == false)
                {
                    DomainEvents.Add(new TodoItemCompletedEvent(this));
                }

                _done = value;
            }
        }

        /// <inheritdoc/>
        public ICollection<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        // Navigation Fields.
        public TodoList List { get; set; }

    }
}