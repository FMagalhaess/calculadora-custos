using calculadora_custos.Models;
using calculadora_custos.Repository;
using calculadora_custos.Results;
using calculadora_custos.Services;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] User user)
    {
        
        var finded = _userRepository.Login(user.Email, user.Password);
         
        return Ok(finded.Result);
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