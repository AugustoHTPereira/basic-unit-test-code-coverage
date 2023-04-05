using Testing.Core.Models;

namespace Testing.Core.Abstractions.Repositories;

public interface IUserRepository
{
    Task<User> FindByIdAsync(Guid id);
    Task<User> FindByEmailAsync(string email);
    Task InsertAsync(User user);
}