using calculadora_custos.Models;
using calculadora_custos.Repository.FixedCosts;
using calculadora_custos.Results;
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

    [Authorize]
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] FixedCost fixedCost)
    {
        var userId = CurrentUserId;
        fixedCost.UserId = userId;
        var fixedCostUpdated = await fixedCostsRepository.UpdateFixedCost(id,fixedCost);
        if(!fixedCostUpdated.IsSuccess)
            return BadRequest(Result<FixedCost>.Fail(fixedCostUpdated.Error));
        return Ok(fixedCostUpdated);
    }

    [Authorize]
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var toDelete = await fixedCostsRepository.DeleteFixedCost(id);
        if(!toDelete.IsSuccess)
            return BadRequest(toDelete);
        
        return NoContent();
    }
}