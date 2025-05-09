using calculadora_custos.Models;
using calculadora_custos.Results;

namespace calculadora_custos.Repository;

public interface IUserRepository
{
    User CreateUser(User user);
    Task<Result<User>> Login  (string username, string password);
}