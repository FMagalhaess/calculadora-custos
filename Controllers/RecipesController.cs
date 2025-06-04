using calculadora_custos.DTO;
using calculadora_custos.Models;
using calculadora_custos.Repository;
using calculadora_custos.Results;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController(IRecipeRepository recipeRepository) : BaseForControllerWithJwt
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
            recipe.UserId = CurrentUserId;
            var createdRecipe = await recipeRepository.CreateRecipe(recipe);
            if (!createdRecipe.IsSuccess)
                return BadRequest(Result<Recipe>.Fail(createdRecipe.Error));
            return Ok(createdRecipe);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] InputRecipeFromDto recipe)
        {
            var updatedRecipe = await recipeRepository.UpdateRecipe(id, recipe);
            if (!updatedRecipe.IsSuccess)
                return BadRequest(updatedRecipe.Error);
            return Ok(Result<Recipe>.Ok(updatedRecipe.Data!));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deletedRecipe = await recipeRepository.DeleteRecipe(id);
            if (!deletedRecipe.IsSuccess)
                return BadRequest(deletedRecipe);
            return Ok(Result<Recipe>.Ok(deletedRecipe.Data!));
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