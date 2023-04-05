using System;

namespace Testing.Core.Models;

public class User
{
    public User(
        string name, 
        string email
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}