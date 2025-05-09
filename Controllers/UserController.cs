using calculadora_custos.Models;
using calculadora_custos.Repository;
using calculadora_custos.Results;
using calculadora_custos.Services;
using calculadora_custos.Services.JWT;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public UserController(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] User user)
    {
        
        Result<User> finded = await _userRepository.Login(user.Email, user.Password);
        
        var token = _tokenService.GenerateToken((finded.Data.Id).ToString());
        return Ok(new { token = $"Bearer {token}" });
    }

    [HttpPost]
    public IActionResult Post([FromBody] User user)
    {
        try
        {
            _userRepository.CreateUser(user);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Created("", user);
    }
}