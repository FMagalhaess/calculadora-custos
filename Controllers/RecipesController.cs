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

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetRecipeById(string id)
        {
            try
            {
                int.TryParse(id, out int idToSearch);
                Recipe recipe = _recipeRepository.GetRecipeById(idToSearch);
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
        [Route("ingredients/{id}")]
        public IActionResult GetIngredientsById(int id)
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
        [HttpGet]
        [Route("delivery/{id}")]
        public IActionResult GetDeliveryCosts(int id)
        {
            try
            {
                List<DeliveryCostReturnedByRecipeDTO> recipe = _recipeRepository.GetDeliveryCostsById(id);
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("preparation/{id}")]
        public IActionResult GetPreparationCosts(int id)
        {
            try
            {
                List<DeliveryCostReturnedByRecipeDTO> recipe = _recipeRepository.GetPreparationCostsById(id);
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("presentation/{id}")]
        public IActionResult GetPresentationCosts(int id)
        {
            try
            {
                List<DeliveryCostReturnedByRecipeDTO> recipe = _recipeRepository.GetPresentationCostsById(id);
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}