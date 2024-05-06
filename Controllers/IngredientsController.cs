using calculadora_custos.Models;
using calculadora_custos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers;

[ApiController]
[Route("[controller]")]
public class IngredientsController : ControllerBase
{
    private readonly IIngredientRepository _IngredientRepository;
    public IngredientsController(IIngredientRepository ingredientRepository)
    {
        _IngredientRepository = ingredientRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World");
    }

    [HttpPost]
    public IActionResult Create([FromBody] Ingredient ingredient )
    {
        try
        {
            Ingredient CreatedRecipe = _IngredientRepository.CreateIngredient(ingredient);
            return Created("", CreatedRecipe);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
