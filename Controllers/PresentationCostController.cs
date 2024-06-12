using calculadora_custos.Models;
using calculadora_custos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers;

[ApiController]
[Route("[controller]")]
public class PresentationCostController : ControllerBase
{
    private readonly IPresentationCostRepository _presentationCostRepository;
    public PresentationCostController(IPresentationCostRepository presentationCostRepository)
    {
        _presentationCostRepository = presentationCostRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_presentationCostRepository.GetPresentationCost());
    }

    [HttpPost]
    public IActionResult Create([FromBody] PresentationCost presentationCost )
    {
        try
        {
            PresentationCost CreatedPresentation = _presentationCostRepository.CreatePresentationCost(presentationCost);
            return Created("", CreatedPresentation);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
