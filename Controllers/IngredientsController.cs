using calculadora_custos.Models;
using calculadora_custos.Repository;
using calculadora_custos.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers;

[ApiController]
[Route("[controller]")]
public class IngredientsController(IIngredientRepository ingredientRepository) : BaseForControllerWithJwt
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await ingredientRepository.GetIngredients());
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Ingredient ingredient )
    {
        // this current id come from "BaseForControllerWithJwt"
        ingredient.UserId = CurrentUserId;
        Result<Ingredient> createdIngredient = await ingredientRepository.CreateIngredient(ingredient);
        return Created("", createdIngredient);
    }
    
    [Authorize]
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] Ingredient ingredient)
    {
        var userId = CurrentUserId;
        ingredient.UserId = userId;
        Result<Ingredient> updateIngredient = await ingredientRepository.UpdateIngredient(id, ingredient);
        if (!updateIngredient.IsSuccess)
            return BadRequest(Result<Ingredient>.Fail(updateIngredient.Error));
        return Ok(updateIngredient);

    }
    
    [Authorize]
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        
        var deleteIngredient = await ingredientRepository.DeleteIngredient(id);
        if (!deleteIngredient.IsSuccess)
            return BadRequest(deleteIngredient.Error);
        return NoContent();
       
    }
}
