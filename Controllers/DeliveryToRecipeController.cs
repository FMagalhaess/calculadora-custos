using calculadora_custos.Models;
using calculadora_custos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers;

[ApiController]
[Route("[controller]")]
public class DeliveryCostToRecipeController : ControllerBase
{
    private readonly IDeliveryCostsToRecipe _deliveryCostsToRecipe;
    public DeliveryCostToRecipeController(IDeliveryCostsToRecipe deliveryCostsToRecipe)
    {
        _deliveryCostsToRecipe = deliveryCostsToRecipe;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_deliveryCostsToRecipe.GetDeliveryCostsToRecipe());
    }

    [HttpPost]
    public IActionResult Create([FromBody] DeliveryToRecipe deliveryCostsToRecipe )
    {
        try
        {
            DeliveryToRecipe CreatedDeliveryCost =
            _deliveryCostsToRecipe.CreateDeliveryCostsToRecipe(deliveryCostsToRecipe.RecipeId, deliveryCostsToRecipe.DeliveryCostId);
            return Created("", CreatedDeliveryCost);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}