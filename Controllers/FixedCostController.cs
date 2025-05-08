using calculadora_custos.Models;
using calculadora_custos.Repository.FixedCosts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers;
[ApiController]
[Route("[controller]")]
public class FixedCostController(IFixedCostsRepository fixedCostsRepository) : BaseForControllerWithJwt
{
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var fixedCost = await fixedCostsRepository.GetAllFixedCost();
        if (!fixedCost.IsSuccess)
            return BadRequest(fixedCost);
        return Ok(fixedCost);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FixedCost fixedCost)
    {
        var userId = CurrentUserId;
        fixedCost.UserId = userId;
        var created = await fixedCostsRepository.CreateFixedCost(fixedCost);
        if(!created.IsSuccess)
            return BadRequest(created);
        return Ok(created);
    }
}