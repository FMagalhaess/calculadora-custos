using calculadora_custos.DTO;
using calculadora_custos.Models;
using calculadora_custos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;
        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_recipeRepository.GetRecipes());
        }

        [HttpPost]
        public IActionResult Create([FromBody] InputRecipeFromDTO recipe)
        {
            try
            {
                Recipe createdRecipe = _recipeRepository.CreateRecipe(recipe);
                return Ok(createdRecipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                List<IngredientReturnedByRecipeIdDTO> recipe = _recipeRepository.IngredientsReturnedByRecipeId(id);
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}