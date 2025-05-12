using calculadora_custos.Models;
using calculadora_custos.Repository.VariableCosts;
using calculadora_custos.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers;

[ApiController]
[Route("[controller]")]
public class VariableCostController(IVariableCostsRepository variableCostsRepository): BaseForControllerWithJwt
{
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var list = await variableCostsRepository.GetAllVariableCosts();
        return Ok(Result<List<VariableCost>>.Ok(list));
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] VariableCost variableCost)
    {
        var userId = CurrentUserId;
        variableCost.UserId = userId;
        var created = await variableCostsRepository.CreateVariableCost(variableCost);
        if (!created.IsSuccess)
            return BadRequest(created);
        return Created("", created);
    }

    [Authorize]
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await variableCostsRepository.Delete(id);
        return NoContent();
    }

    [Authorize]
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] VariableCost variableCost)
    {
        var userId = CurrentUserId;
        variableCost.UserId = userId;
        var updated = await variableCostsRepository.UpdateVariableCost(id, variableCost);
        if(!updated.IsSuccess)
            return BadRequest(Result<VariableCost>.Fail(updated.Error));
        return Ok(Result<VariableCost>.Ok(variableCost));
    }
}