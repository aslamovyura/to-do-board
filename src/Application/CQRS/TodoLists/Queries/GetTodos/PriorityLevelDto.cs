namespace Application.CQRS.TodoLists.Queries.GetTodos
{
    /// <summary>
    /// Defines DTO for priority level.
    /// </summary>
    public class PriorityLevelDto
    {
        /// <summary>
        /// Priority value (int).
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Name for priotiry value.
        /// </summary>
        public string Name { get; set; }
    }
}