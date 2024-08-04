using CwkSocial.Api.Extensions;
using Microsoft.AspNetCore.Identity;
using Notea.Domain.Context;
using Notea.Domain.Models.Users;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication();

builder.RegisterServices(typeof(Program));

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

app.MapIdentityApi<User>();

app.RegisterPipelineComponents(typeof(Program));

app.Run();