using calculadora_custos.Models;
using calculadora_custos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers;

[ApiController]
[Route("[controller]")]
public class PreparationToRecipeController : ControllerBase
{
    private readonly IPreparationToRecipe _preparationToRecipeRepository;
    public PreparationToRecipeController(IPreparationToRecipe preparationToRecipeRepository)
    {
        _preparationToRecipeRepository = preparationToRecipeRepository;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_preparationToRecipeRepository.GetPreparationToRecipe());
    }
    [HttpPost]
    public IActionResult Post([FromBody] PreparationToRecipe preparationToRecipe)
    {
        return Ok(_preparationToRecipeRepository.CreatePreparationToRecipe(preparationToRecipe));
    }
}