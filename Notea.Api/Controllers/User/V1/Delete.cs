using Microsoft.AspNetCore.Mvc;

namespace Notea.Api.Controllers.User.V1;

public sealed partial class UsersController
{
    /// <summary>
    /// Deletes an existing user by their unique identifier.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to delete.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// Returns a 200 Ok status code if the user is successfully deleted.
    /// </returns>
    /// <remarks>
    /// This method is intended for deleting users from the system.
    /// It expects a DELETE request with the user ID specified in the URL.
    /// </remarks>
    /// <response code="200">The user was successfully deleted.</response>
    /// <response code="404">The requested user could not be found.</response>
    /// <response code="500">An internal server error occurred while processing the request.</response>
    [HttpDelete("{userId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task Delete(string userId) =>
       await _userService.DeleteUserAsync(userId);
}