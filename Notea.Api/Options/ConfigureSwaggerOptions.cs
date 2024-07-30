using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Notea.Api.Options;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
        }
    }

    private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
    {
        var info = new OpenApiInfo
        {
            Title = "Notea API",
            Version = description.ApiVersion.ToString(),
            Description = "An ASP.NET Core Web API for managing Notes.",
            TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "LinkedIn",
                Url = new Uri("https://www.linkedin.com/in/rouisaek/")
            },
            License = new OpenApiLicense
            {
                Name = "MIT License",
                Url = new Uri("https://github.com/rouisaek/Notea/blob/main/LICENSE.txt")
            }
        };

        if (description.IsDeprecated)
        {
            info.Description = "This API version has been deprecated";
        }

        return info;
    }
}
