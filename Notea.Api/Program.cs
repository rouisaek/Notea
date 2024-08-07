using Notea.Api.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.RegisterServices(typeof(Program));

WebApplication app = builder.Build();

app.RegisterPipelineComponents(typeof(Program));

app.Run();