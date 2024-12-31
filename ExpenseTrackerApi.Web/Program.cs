using ExpenseTrackerApi.Infrastructure.Persistence.Extensions;
using ExpenseTrackerApi.Web.Constants;
using ExpenseTrackerApi.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFileByEnvName();

builder.Services.AddOpenApi();
builder.Services.AddPersistence(builder.Configuration.GetConnectionString(ConfigurationConstants.ConnectionStringName));

var app = builder.Build();
if (!app.Environment.IsProduction())
{
    app.MapOpenApi();
}

app.Run();