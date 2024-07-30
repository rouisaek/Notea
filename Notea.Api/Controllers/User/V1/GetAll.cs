using Microsoft.AspNetCore.Mvc;
using Notea.Domain.Users.Responses;

namespace Notea.Api.Controllers.User.V1;


public sealed partial class UsersController
{
    /// <summary>
    /// Retrieves a collection of all users available in the system.
    /// </summary>
    /// <returns>
    /// A collection of <see cref="GetUserDto"/> objects representing the users.
    /// Each object contains the details of a user.
    /// </returns>
    /// <remarks>
    /// This method is designed to fetch all user records from the database.
    /// It's intended for use by administrators or any user with the necessary permissions.
    /// 
    /// <example>
    /// Sample request:
    /// 
    ///     GET: /api/v1/users
    /// </example>
    /// </remarks>
    /// <response code="200">
    /// The request was successful, and the response body contains a collection of user objects.
    /// </response>
    /// <response code="500">
    /// An internal server error occurred while attempting to fetch the users.
    /// This could be due to a database connection issue or an unexpected error in the server.
    /// </response>
    [HttpGet]
    [ProducesResponseType(500)]
    [ProducesResponseType(200, Type = typeof(IList<UserResponse>))]
    public async Task<IActionResult> GetAll() =>
           Ok(await _userService.GetUsersAsync());
}
