using System.Data;

namespace ExpenseTrackerApi.Infrastructure.Persistence.Connection;

public interface IDbConnectionFactory
{
    Task<IDbConnection> ConnectAsync();
}