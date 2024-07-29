using Notea.Data.Repositories;
using Notea.Domain.Contracts;
using Notea.Domain.Services;


namespace Notea.Api.Registrars.Build;

public class DependenciesRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder) => builder.Services
        .AddTransient<UserService>()
        .AddTransient<IUserRepository, UserRepository>();
}