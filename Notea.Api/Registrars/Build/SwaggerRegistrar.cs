using System.Reflection;
using Notea.Api.Options;

namespace Notea.Api.Registrars.Build;

public class SwaggerRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(options =>
        {
            // using System.Reflection;
            // var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            // options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
    }
}
