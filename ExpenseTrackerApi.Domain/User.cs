using CSharpFunctionalExtensions;

namespace ExpenseTrackerApi.Domain;

public sealed class User : Entity<Guid>
{
    public required string Username { get; init; }
    public required string PasswordHash { get; init; }
}