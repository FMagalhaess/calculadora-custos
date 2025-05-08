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
    public IActionResult Get()
    {
        return Ok(ingredientRepository.GetIngredients());
    }
    [Authorize]
    [HttpPost]
    public IActionResult Create([FromBody] Ingredient ingredient )
    {
        // this current id come from "BaseForControllerWithJwt"
        ingredient.UserId = CurrentUserId;
        Result<Ingredient> createdIngredient = ingredientRepository.CreateIngredient(ingredient);
        return Created("", createdIngredient);
    }
    
    [Authorize]
    [HttpPut]
    [Route("{id}")]
    public IActionResult Update(string id, [FromBody] Ingredient ingredient)
    {
        try
        {
            Ingredient updateIngredient = ingredientRepository.UpdateIngredient(id, ingredient);
            return Ok(updateIngredient);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [Authorize]
    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(string id)
    {
        
        var deleteIngredient = ingredientRepository.DeleteIngredient(id);
        if (!deleteIngredient.IsSuccess)
            return BadRequest(deleteIngredient.Error);
        return NoContent();
       
    }
}
