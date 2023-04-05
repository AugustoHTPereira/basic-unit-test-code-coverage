using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Testing.Application.Managers;
using Testing.Application.ViewModels;
using Testing.Core.Abstractions.Services;
using Testing.Core.Models;

namespace Testing.Test.Application.Managers;

public class UserManagerTest
{
    [Test]
    public void ShouldCreateUserTest()
    {
        var viewModel = new CreateUserViewModel
        {
            Email = "augustohtp8@gmail.com",
            Password = "1234",
            Name = "Augusto Pereira"
        };

        var userService = new Mock<IUserService>();
        userService.Setup(x => x.CreateAsync(new User(viewModel.Name, viewModel.Email), viewModel.Password));

        var userManager = new UserManager(userService.Object);
        Assert.DoesNotThrowAsync(() => userManager.CreateAsync(viewModel));
    }
}