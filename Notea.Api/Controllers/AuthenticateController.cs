using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Notea.Api.Controllers;



[ApiController]
[Tags("Notea.Api")]
public class AuthenticateController : ControllerBase
{
    [Route("/logout")]
    [HttpPost]
    public async Task<IResult> Logout(SignInManager<Domain.Models.Users.User> signInManager, [FromBody] object empty)
    {
        if (empty != null)
        {
            await signInManager.SignOutAsync();
            return Results.Ok();
        }

        return Results.Unauthorized();
    }
}