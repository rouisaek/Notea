using CwkSocial.Api.Extensions;
using Microsoft.AspNetCore.Identity;
using Notea.Domain.Context;
using Notea.Domain.Models.Users;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices(typeof(Program));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

app.RegisterPipelineComponents(typeof(Program));

app.Run();