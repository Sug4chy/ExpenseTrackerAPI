using ExpenseTrackerApi.Infrastructure.Persistence.Connection;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTrackerApi.Infrastructure.Persistence.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string? connectionString)
        => services.AddSingleton<IDbConnectionFactory>(
            _ => new NpgsqlDbConnectionFactory(connectionString));
}