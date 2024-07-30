using Microsoft.AspNetCore.Mvc;
using Notea.Domain.Users.Requests;



namespace Notea.Api.Controllers.User.V1;


public sealed partial class UsersController
{
    /// <summary>
    /// Creates a new user with the provided details.
    /// </summary>
    /// <param name="createUser">The data transfer object containing the details of the user to be created.</param>
    /// <returns>
    /// A <see cref="Task{IActionResult}"/> representing the asynchronous operation.
    /// Returns a 201 Created status code if the user is successfully created.
    /// </returns>
    /// <remarks>
    /// This method is intended for creating new users in the system.
    /// It expects a POST request with a JSON body containing the user details.
    /// </remarks>
    /// <response code="201">The user was successfully created.</response>
    /// <response code="400">The request is invalid, possibly due to missing or invalid data in the request body.</response>
    /// <response code="500">An internal server error occurred while processing the request.</response>
    [HttpPost]
    [ProducesResponseType(201)] // Created
    [ProducesResponseType(400)] // Bad Request
    [ProducesResponseType(500)] // Server Error
    public async Task<IActionResult> Post(CreateUserRequest createUser)
    {
        await _userService.CreateUserAsync(createUser);
        return Created();
    }
}
