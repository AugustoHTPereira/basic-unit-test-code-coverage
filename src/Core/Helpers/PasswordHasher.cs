using System.Text;

namespace Testing.Core.Helpers;

public static class PasswordHasher
{
    public static string HashPassword(this string decoded)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(decoded));
    }
}