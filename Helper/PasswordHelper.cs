using calculadora_custos.Models;
using Microsoft.AspNetCore.Identity;
namespace calculadora_custos.Helper;

public static class PasswordHelper
{
    public static string HashPassword(User user, string password)
    {
        var hasher = new PasswordHasher<User>();
        return hasher.HashPassword(user, password);
    }

    public static bool VerifyPassword(User user, string password, string hashedPassword)
    {
        var hasher = new PasswordHasher<User>();
        var result = hasher.VerifyHashedPassword(user, hashedPassword, password);
        return result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded;
    }
}