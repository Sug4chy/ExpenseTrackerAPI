using ExpenseTrackerApi.Domain;

namespace ExpenseTrackerApi.Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task<bool> CheckIfUserExistsByUsernameAsync(string username, CancellationToken ct = default);
    Task AddUserAsync(User user, CancellationToken ct = default);
}