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
        public IActionResult Create([FromBody] Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}