using Microsoft.AspNetCore.Mvc;
using Notea.Domain.User.Models.Responses;


namespace Notea.Api.Controllers.User.V1;


public sealed partial class UsersController
{
    /// <summary>
    /// Retrieves the details of a specific user by their unique identifier.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to retrieve.</param>
    /// <returns>
    /// A <see cref="GetUserDto"/> object containing the details of the requested user.
    /// </returns>
    /// <remarks>
    /// This method is designed to fetch a single user record from the database based on the provided user ID.
    /// It's intended for use by administrators or any user with the necessary permissions to view user details.
    /// 
    /// <example>
    /// Sample request:
    /// 
    ///     GET: /api/v1/users/123
    /// </example>
    /// </remarks>
    /// <response code="200">
    /// The request was successful, and the response body contains the details of the requested user.
    /// </response>
    /// <response code="404">
    /// The requested user could not be found. This could be due to the user ID not existing in the database.
    /// </response>
    /// <response code="500">
    /// An internal server error occurred while attempting to fetch the user.
    /// This could be due to a database connection issue or an unexpected error in the server.
    /// </response>
    [HttpGet("{userId}")]
    [ProducesResponseType(404)] // Not Found
    [ProducesResponseType(500)] // Server Error
    [ProducesResponseType(200, Type = typeof(UserResponse))] // Success
    public async Task<IActionResult> GetById(string userId) =>
        Ok(await _userService.GetUserByIdAsync(userId));
}
