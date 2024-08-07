namespace Notea.Api.Registrars.Build;

public class AuthenticationRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(options =>
        {

        });
    }
}