using Microsoft.AspNetCore.Mvc;
using Notea.Api.Routes;
using Notea.Domain.Services;

namespace Notea.Api.Controllers.User.V1;


[Route(BaseRoutes.USER)]
[ApiController]
public sealed partial class UsersController(UserService userService) : ControllerBase
{
    private readonly UserService _userService = userService;
}
