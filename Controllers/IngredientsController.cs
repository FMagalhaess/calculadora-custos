using System.Security.Claims;
using calculadora_custos.Models;
using calculadora_custos.Repository;
using calculadora_custos.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace calculadora_custos.Controllers;

[ApiController]
[Route("[controller]")]
public class IngredientsController : BaseForControllerWithJwt
{
    private readonly IIngredientRepository _IngredientRepository;
    public IngredientsController(IIngredientRepository ingredientRepository)
    {
        _IngredientRepository = ingredientRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_IngredientRepository.GetIngredients());
    }
    [Authorize]
    [HttpPost]
    public IActionResult Create([FromBody] Ingredient ingredient )
    {
        ingredient.UserId = CurrentUserId;
        Ingredient createdIngredient = _IngredientRepository.CreateIngredient(ingredient);
        return Created("", createdIngredient);
    }
    
    [Authorize]
    [HttpPut]
    [Route("{id}")]
    public IActionResult Update(string id, [FromBody] Ingredient ingredient)
    {
        try
        {
            Ingredient updateIngredient = _IngredientRepository.UpdateIngredient(id, ingredient);
            return Ok(updateIngredient);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(string id)
    {
        try
        {
            _IngredientRepository.DeleteIngredient(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
