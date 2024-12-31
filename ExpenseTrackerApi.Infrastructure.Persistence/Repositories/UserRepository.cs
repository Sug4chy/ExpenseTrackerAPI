using System.Data;
using Dapper;
using ExpenseTrackerApi.Application.Abstractions.Repositories;
using ExpenseTrackerApi.Domain;
using ExpenseTrackerApi.Infrastructure.Persistence.Connection;

namespace ExpenseTrackerApi.Infrastructure.Persistence.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public UserRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public Task<bool> CheckIfUserExistsByUsernameAsync(string username, CancellationToken ct = default)
        => ExecuteAsync(
            con => con.QueryFirstAsync<bool>(
                """
                SELECT COUNT(1) > 0
                FROM "user" u
                WHERE u.username = @username
                """, new { username }), ct);

    public Task AddUserAsync(User user, CancellationToken ct = default)
        => ExecuteAsync(
            con => con.ExecuteAsync(
                """
                INSERT INTO "user" (id, username, password_hash)
                VALUES (@id, @username, @password_hash)
                """, new { id = user.Id, username = user.Username, password_hash = user.PasswordHash }), ct);

    private async Task<T> ExecuteAsync<T>(Func<IDbConnection, Task<T>> func, CancellationToken ct = default)
    {
        using var con = await _dbConnectionFactory.ConnectAsync(ct);

        ct.ThrowIfCancellationRequested();

        return await func(con);
    }
}