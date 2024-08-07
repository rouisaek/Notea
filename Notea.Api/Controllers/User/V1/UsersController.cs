using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notea.Api.Routes;
using Notea.Domain.User;

namespace Notea.Api.Controllers.User.V1;


[Route(BaseRoutes.USER)]
[ApiController]
[Authorize]
public sealed partial class UsersController(UserService userService) : ControllerBase
{
    private readonly UserService _userService = userService;
}
