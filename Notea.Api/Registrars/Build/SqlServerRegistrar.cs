using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Notea.Domain.Context;

namespace Notea.Api.Registrars.Build;

public class SqlServerRegistrar : IWebApplicationBuilderRegistrar
{

    public void RegisterServices(WebApplicationBuilder builder)
    {
        var env = builder.Environment;
        var config = builder.Configuration;
        var services = builder.Services;

        if (env.IsDevelopment())
            services.AddDbContext<ApplicationDbContext>(options =>
                      options.UseSqlite(config.GetConnectionString("SQLite_Database")));

        // services.AddDbContext<ApplicationDbContext>(options =>
        //         options.UseSqlServer(config.GetConnectionString("DevelopmentConnection"),
        //             b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)));

        else services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("ProductionConnection"),
                    b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)));
    }
}