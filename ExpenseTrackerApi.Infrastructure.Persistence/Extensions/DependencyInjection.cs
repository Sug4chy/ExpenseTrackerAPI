using ExpenseTrackerApi.Application.Abstractions.Repositories;
using ExpenseTrackerApi.Infrastructure.Persistence.Connection;
using ExpenseTrackerApi.Infrastructure.Persistence.Migrations;
using ExpenseTrackerApi.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTrackerApi.Infrastructure.Persistence.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string? connectionString)
        => services.AddSingleton<IDbConnectionFactory>(
                _ => new NpgsqlDbConnectionFactory(connectionString))
            .AddSingleton(
                _ => new MigratorDbInitializer(connectionString))
            .AddRepositories();

    private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services
            .AddScoped<IUserRepository, UserRepository>();
}