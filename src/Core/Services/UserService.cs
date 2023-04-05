using Testing.Core.Abstractions.Repositories;
using Testing.Core.Abstractions.Services;
using Testing.Core.Helpers;
using Testing.Core.Models;

namespace Testing.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task CreateAsync(User user, string password)
    {
        var foundedUser = await _userRepository.FindByEmailAsync(user.Email);
        if (foundedUser != null)
            throw new Exception("The email already is in use");

        user.Password = password.HashPassword();
        await _userRepository.InsertAsync(user);
    }
}