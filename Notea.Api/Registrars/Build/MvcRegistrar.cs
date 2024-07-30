using System.Text.Json;
using System.Text.Json.Serialization;
using Asp.Versioning;
using Asp.Versioning.Conventions;


namespace Notea.Api.Registrars.Build;

public class MvcRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddMvc(options =>
        {
            options.SuppressAsyncSuffixInActionNames = false;
        });

        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        }

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

        builder.Services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        }).AddMvc(options =>
        {
            options.Conventions.Add(new VersionByNamespaceConvention());
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddProblemDetails();
    }
}