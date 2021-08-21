using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// List of To-Do Items.
    /// </summary>
    public class TodoList
    {
        /// <summary>
        /// List Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// List title.
        /// </summary>
        public string Title { get; set; }

        ///// <summary>
        ///// List Colour.
        ///// </summary>
        //public Colour Colour { get; set; }

        // Navigation fields.

        /// <summary>
        /// Belonging To-Do Items.
        /// </summary>
        public ICollection<TodoItem> Items { get; set; } = new List<TodoItem>();
    }
}