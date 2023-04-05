using Testing.Application.ViewModels;
using Testing.Core.Abstractions.Services;
using Testing.Core.Models;

namespace Testing.Application.Managers;

public class UserManager
{
    private readonly IUserService _userService;

    public UserManager(IUserService userService)
    {
        _userService = userService;
    }

    public async Task CreateAsync(CreateUserViewModel viewModel)
    {
        var user = new User(
            name: viewModel.Name,
            email: viewModel.Email
        );

        await _userService.CreateAsync(user, viewModel.Password);
    }
}