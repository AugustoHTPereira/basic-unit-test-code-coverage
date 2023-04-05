using Testing.Core.Models;

namespace Testing.Core.Abstractions.Services;

public interface IUserService
{
    Task CreateAsync(User user, string password);
}