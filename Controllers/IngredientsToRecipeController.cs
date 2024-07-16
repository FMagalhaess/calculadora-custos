using calculadora_custos.Models;
using calculadora_custos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers;

[ApiController]
[Route("[controller]")]
public class IngredientsToRecipeController : ControllerBase
{
    private readonly IIngredientsToRecipe _ingredientToRecipeRepository;
    public IngredientsToRecipeController(IIngredientsToRecipe ingredientToRecipeRepository)
    {
        _ingredientToRecipeRepository = ingredientToRecipeRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_ingredientToRecipeRepository.GetIngredientsToRecipe());
    }

    [HttpPost]
    public IActionResult Create([FromBody] IngredientToRecipe ingredient )
    {
        try
        {
            IngredientToRecipe CreatedIngredient = _ingredientToRecipeRepository.CreateIngredientsToRecipe(ingredient);
            return Created("", CreatedIngredient);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
