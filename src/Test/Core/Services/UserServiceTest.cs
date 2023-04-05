using NUnit.Framework;
using Testing.Core.Abstractions.Repositories;
using Testing.Core.Services;
using Moq;
using Testing.Core.Models;
using System.Threading.Tasks;
using System;

namespace Testing.Test.Core.Services;

public class UserServiceTest
{
    [Test]
    public void CreateUserWithEmailInUse()
    {
        var user = new User(
            name: "Augusto Pereira",
            email: "augustohtp8@gmail.com"
        );

        var userRepository = new Mock<IUserRepository>();
        userRepository.Setup(x => x.FindByEmailAsync(user.Email)).Returns(Task.FromResult(user));

        var userService = new UserService(userRepository.Object);
        Assert.ThrowsAsync<Exception>(() => userService.CreateAsync(user, "1234"), "The email already is in use");
    }

    [Test]
    public void CreateUserWithValidEmail()
    {
        var user = new User(
            name: "Augusto Pereira",
            email: "augustohtp8@gmail.com"
        );

        var userRepository = new Mock<IUserRepository>();
        userRepository.Setup(x => x.FindByEmailAsync(user.Email)).Returns(Task.FromResult((User)null));

        var userService = new UserService(userRepository.Object);
        Assert.DoesNotThrowAsync(() => userService.CreateAsync(user, "1234"));
    }
}