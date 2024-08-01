using Microsoft.AspNetCore.Mvc;
using Notea.Domain.Users.Models.Requests;


namespace Notea.Api.Controllers.User.V1;

// UPDATE USER
public sealed partial class UsersController
{
    /// <summary>
    /// Updates the details of an existing user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to update.</param>
    /// <param name="updateUser">The data transfer object containing the updated details of the user.</param>
    /// <returns>
    /// A <see cref="Task{IActionResult}"/> representing the asynchronous operation.
    /// Returns a 204 No Content status code if the user is successfully updated.
    /// </returns>
    /// <remarks>
    /// This method is intended for updating the details of existing users in the system.
    /// It expects a PUT request with a JSON body containing the updated user details.
    /// </remarks>
    /// <response code="200">The user was successfully updated.</response>
    /// <response code="400">The request is invalid, possibly due to missing or invalid data in the request body.</response>
    /// <response code="404">The requested user could not be found.</response>
    /// <response code="500">An internal server error occurred while processing the request.</response>
    [HttpPut("{userId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Update(string userId, UpdateUserRequest updateUser)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(await _userService.UpdateUserAsync(userId, updateUser));
    }
}
