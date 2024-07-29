namespace Notea.Api.Registrars.Build;

public class CorsRegistrar : IWebApplicationBuilderRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddCors(options => options.AddPolicy("Cors_Dev_Policy",
                builder => builder
                    .AllowAnyOrigin()
                        .AllowAnyMethod()
                            .AllowAnyHeader()));

            Console.WriteLine("Applying development CORS policy.");
        }
        else
        {
            builder.Services.AddCors(options => options.AddPolicy("Cors_Pro_Policy",
                builder => builder
                    .WithOrigins("https://example.com")
                        .WithMethods("GET", "POST")
                            .WithHeaders("Content-Type")));

            Console.WriteLine("Applying production CORS policy.");
        }
    }
}