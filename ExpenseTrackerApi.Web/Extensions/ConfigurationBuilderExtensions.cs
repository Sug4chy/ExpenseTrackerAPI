using System;
using Microsoft.Extensions.Configuration;

namespace ExpenseTrackerApi.Web.Extensions;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder AddJsonFileByEnvName(this IConfigurationBuilder builder)
        => builder.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json");
}