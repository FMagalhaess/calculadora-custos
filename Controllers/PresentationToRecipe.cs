using calculadora_custos.Models;
using calculadora_custos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers;

[ApiController]
[Route("[controller]")]
public class PresentationToRecipeController : ControllerBase
{
    private readonly IPresentationToRecipe _presentationToRecipeRepository;
    public PresentationToRecipeController(IPresentationToRecipe presentionToRecipeRepository)
    {
        _presentationToRecipeRepository = presentionToRecipeRepository;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_presentationToRecipeRepository.GetPresentationsToRecipe());
    }
    [HttpPost]
    public IActionResult Post([FromBody] PresentationToRecipe presentationToRecipe)
    {
        return Ok(_presentationToRecipeRepository.CreatePresentationToRecipe(presentationToRecipe.RecipeId, presentationToRecipe.PresentationId));
    }
}