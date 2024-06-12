using calculadora_custos.Models;
using calculadora_custos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers;

[ApiController]
[Route("[controller]")]
public class PreparationCostController : ControllerBase
{
    private readonly IPreparationCostRepository _preparationCostRepository;
    public PreparationCostController(IPreparationCostRepository preparationCostRepository)
    {
        _preparationCostRepository = preparationCostRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_preparationCostRepository.GetPreparationCost());
    }
    [HttpPost]
    public IActionResult Create([FromBody] PreparationCost preparationCost)
    {
        try
        {
            PreparationCost CreatedPreparation = _preparationCostRepository.CreatePreparationCost(preparationCost);
            return Created("", CreatedPreparation);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}