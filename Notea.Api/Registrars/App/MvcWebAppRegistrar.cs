using Microsoft.AspNetCore.HttpOverrides;
using Notea.Data.Context;

namespace Notea.Api.Registrars.App;

public class MvcWebAppRegistrar : IWebApplicationRegistrar
{
    public void RegisterPipelineComponents(WebApplication app)
    {
        app.UseStatusCodePages();

        // app.UseMiddleware<GlobalErrorHandlingMiddleware>();

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

        // Data seeding.
        using (var scope = app.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;

            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            SeedData.Initialize(context);
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.All
        });

        app.UseAuthorization();

        app.MapControllers();

    }
}
