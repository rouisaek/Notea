using Microsoft.AspNetCore.Identity;
using Notea.Domain.Context;
using Notea.Domain.Models.User;

namespace Notea.Api.Registrars.Build;

public class IdentityRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddIdentityApiEndpoints<ApplicationUser>(options =>
        {

        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>();
    }
}