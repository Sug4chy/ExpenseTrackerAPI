using DbUp;

namespace ExpenseTrackerApi.Infrastructure.Persistence.Migrations;

public sealed class MigratorDbInitializer
{
    private readonly string? _connectionString;

    public MigratorDbInitializer(string? connectionString)
    {
        _connectionString = connectionString;
    }

    public void Migrate()
    {
        EnsureDatabase.For.PostgresqlDatabase(_connectionString);

        var upgradeEngine = DeployChanges.To.PostgresqlDatabase(_connectionString)
            .WithScriptsEmbeddedInAssembly(GetType().Assembly)
            .WithTransaction()
            .LogToConsole()
            .Build();

        if (upgradeEngine.IsUpgradeRequired())
        {
            upgradeEngine.PerformUpgrade();
        }
    }
}