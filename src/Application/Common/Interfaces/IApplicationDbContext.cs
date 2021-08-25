using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    /// <summary>
    /// Interface for application DB context.
    /// </summary>
    public interface IApplicationDbContext
    {
        DbSet<TodoItem> TodoItems { get; set; }
        DbSet<TodoList> TodoLists { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}