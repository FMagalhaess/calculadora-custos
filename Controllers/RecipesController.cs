using calculadora_custos.DTO;
using calculadora_custos.Models;
using calculadora_custos.Repository;
using calculadora_custos.Results;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController(IRecipeRepository recipeRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await recipeRepository.GetRecipes());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRecipeById(string id)
        {
                Result<Recipe> recipe = await recipeRepository.GetRecipeById(id);
                if (!recipe.IsSuccess)
                    return BadRequest(Result<Recipe>.Fail(recipe.Error));
                return Ok(Result<Recipe>.Ok(recipe.Data!));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InputRecipeFromDto recipe)
        {
            var createdRecipe = await recipeRepository.CreateRecipe(recipe);
            if (!createdRecipe.IsSuccess)
                return BadRequest(Result<Recipe>.Fail(createdRecipe.Error));
            return Ok(createdRecipe);
        }
        // [HttpGet]
        // [Route("ingredients/{id}")]
        // public async Task<IActionResult> GetIngredientsById(string id)
        // {
        //         List<IngredientReturnedByRecipeIdDto> recipe = recipeRepository.IngredientsReturnedByRecipeId(id);
        //         return Ok(recipe);
        // }
    }
}