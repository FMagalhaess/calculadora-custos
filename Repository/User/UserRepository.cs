using calculadora_custos.Helper;
using calculadora_custos.Models;
using calculadora_custos.Results;
using calculadora_custos.Services;
using Microsoft.EntityFrameworkCore;

namespace calculadora_custos.Repository;

public class UserRepository : IUserRepository
{
    private readonly IDbContext _context;

    public UserRepository(IDbContext context)
    {
        _context = context;
    }

    public async Task<Result<User>> Login(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email))
            return Result<User>.Fail("Email is required");

        if (string.IsNullOrWhiteSpace(password))
            return Result<User>.Fail("password is required");

        var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (dbUser == null)
        {
            return Result<User>.Fail("User not found");
        }

        if (!PasswordHelper.VerifyPassword(dbUser, password, dbUser.Password))
        {
            return Result<User>.Fail("Invalid password");
        }
        return Result<User>.Ok(dbUser);
    }

    public User CreateUser(User user)
    {
        var _user = user;
        try
        {
            EnsureFields.EnsureNameNotNull(user.Name!);
            EnsureFields.EnsureEmailNotNull(user.Email!);
            EnsureFields.EnsurePasswordNotNull(user.Password!);
            _user.Password = PasswordHelper.HashPassword(user, user.Password!);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        _context.Users.Add(_user);
        _context.SaveChanges();
        return _user;
    }
}