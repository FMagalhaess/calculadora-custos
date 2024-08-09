using calculadora_custos.Models;
using calculadora_custos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers;

[ApiController]
[Route("[controller]")]
public class DeliveryCostController : ControllerBase
{
    private readonly IDeliveryCostRepository _deliveryCostRepository;
    public DeliveryCostController(IDeliveryCostRepository deliveryCostRepository)
    {
        _deliveryCostRepository = deliveryCostRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_deliveryCostRepository.GetAllDeliveryCosts());
    }

    [HttpPost]
    public IActionResult Create([FromBody] DeliveryCost deliveryCost )
    {
        try
        {
            DeliveryCost CreatedRecipe = _deliveryCostRepository.CreateDeliveryCost(deliveryCost);
            return Created("", CreatedRecipe);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPut]
    [Route("{id}")]
    public IActionResult Update(string id, [FromBody] DeliveryCost deliveryCost)
    {
        try
        {
            int.TryParse(id, out int idToSearch);
            _deliveryCostRepository.UpdateDeliveryCost(idToSearch, deliveryCost);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
