using calculadora_custos.Models;
using calculadora_custos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers;

[ApiController]
[Route("[controller]")]
public class IngredientsToRecipeController : ControllerBase
{
    private readonly ICostToRecipe _iCostToRecipeRepository;
    public IngredientsToRecipeController(ICostToRecipe iCostToRecipeRepository)
    {
        _iCostToRecipeRepository = iCostToRecipeRepository;
    }

    // [HttpGet]
    // public IActionResult Get()
    // {
    //     return Ok(_ingredientToRecipeRepository.GetIngredientsToRecipe());
    // }

    // [HttpPost]
    // public IActionResult Create([FromBody] IngredientToRecipe ingredient )
    // {
    //     try
    //     {
    //         IngredientToRecipe createdIngredient = _ingredientToRecipeRepository.CreateIngredientsToRecipe(ingredient.RecipeId, ingredient.IngredientId);
    //         return Created("", createdIngredient);
    //     }
    //     catch (Exception e)
    //     {
    //         return BadRequest(e.Message);
    //     }
    // }
}
