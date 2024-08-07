using Notea.Domain.User;

namespace Notea.Api.Registrars.Build;

public class DependenciesRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder) => builder.Services
        .AddTransient<UserService>();
}