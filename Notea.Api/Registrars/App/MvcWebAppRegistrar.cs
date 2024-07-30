using Microsoft.AspNetCore.HttpOverrides;
using Notea.Domain.Context;

namespace Notea.Api.Registrars.App;

public class MvcWebAppRegistrar : IWebApplicationRegistrar
{
    public void RegisterPipelineComponents(WebApplication app)
    {
        app.UseStatusCodePages();

        if (app.Environment.IsDevelopment())
        {
            app.UseCors("Cors_Dev_Policy");
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseCors("Cors_Pro_Policy");
            app.UseHsts();
        }


        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
        }

        app.UseHttpsRedirection();

        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.All
        });

        app.UseAuthorization();

        app.MapControllers();

    }
}
