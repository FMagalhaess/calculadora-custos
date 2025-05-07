namespace calculadora_custos.Services.JWT;

public interface ITokenService
{
    string GenerateToken(string userId);
}