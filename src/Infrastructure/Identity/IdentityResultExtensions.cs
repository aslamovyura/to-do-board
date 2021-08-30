using System.Linq;
using Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    /// <summary>
    /// Identity result extensions.
    /// </summary>
    public static class IdentityResultExtensions
    {
        /// <summary>
        /// Convert from Identity result to Application result.
        /// </summary>
        /// <param name="result">Identity result.</param>
        /// <returns>Application result.</returns>
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}