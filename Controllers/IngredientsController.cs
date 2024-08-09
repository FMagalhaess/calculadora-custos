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
        return Ok(_IngredientRepository.GetIngredients());
    }

    [HttpPost]
    public IActionResult Create([FromBody] Ingredient ingredient )
    {
        try
        {
            Ingredient CreatedIngredient = _IngredientRepository.CreateIngredient(ingredient);
            return Created("", CreatedIngredient);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPut]
    [Route("{id}")]
    public IActionResult Update(string id, [FromBody] Ingredient ingredient)
    {
        try
        {
            _IngredientRepository.UpdateIngredient(id, ingredient);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
