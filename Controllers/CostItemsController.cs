using calculadora_custos.Models;
using Microsoft.AspNetCore.Mvc;

namespace calculadora_custos.Controllers;

[ApiController]
[Route("[controller]")]
public class CostItemsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Post([FromBody] CostItem costItem)
    {
        return Ok(costItem);
    }
}