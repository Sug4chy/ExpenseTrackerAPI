using ExpenseTrackerApi.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFileByEnvName();

builder.Services.AddOpenApi();

var app = builder.Build();
if (!app.Environment.IsProduction())
{
    app.MapOpenApi();
}

app.Run();
