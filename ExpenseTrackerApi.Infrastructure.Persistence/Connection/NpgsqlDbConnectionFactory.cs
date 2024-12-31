using System.Data;
using Npgsql;

namespace ExpenseTrackerApi.Infrastructure.Persistence.Connection;

public sealed class NpgsqlDbConnectionFactory : IDbConnectionFactory
{
    private readonly string? _connectionString;

    public NpgsqlDbConnectionFactory(string? connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IDbConnection> ConnectAsync(CancellationToken ct = default)
    {
        var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync(ct);
        return connection;
    }
}