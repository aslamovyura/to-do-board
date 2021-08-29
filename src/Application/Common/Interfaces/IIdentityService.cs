using System.Threading.Tasks;
using Application.Common.Models;

namespace Application.Common.Interfaces
{
    /// <summary>
    /// Service to manage user identity.
    /// </summary>
    public interface IIdentityService
    {
        /// <summary>
        /// Get user name by ID.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <returns>User name, if exists; otherwise, null.</returns>
        Task<string> GetUserNameAsync(string userId);

        /// <summary>
        /// Defines whether user is in specified role.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="role">Specified role.</param>
        /// <returns>True if user is in specified role; otherwise, false.</returns>
        Task<bool> IsInRoleAsync(string userId, string role);

        /// <summary>
        /// Authorize user.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="policyName">Name of authrization policy.</param>
        /// <returns>True if authorization completed successfully; otherwise, false.</returns>
        Task<bool> AuthorizeAsync(string userId, string policyName);

        /// <summary>
        /// Create new User.
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">User password.</param>
        /// <returns>Processing results and ID of new User.</returns>
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        /// <summary>
        /// Delete User by ID.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <returns>Processing result.</returns>
        Task<Result> DeleteUserAsync(string userId);
    }
}