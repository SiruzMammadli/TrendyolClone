using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers;

[Route("api/stores")]
[ApiController]
public class StoresController : ControllerBase
{
    [HttpPost]
    public IActionResult Create()
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }

    [HttpGet("{id:guid}/products")]
    public IActionResult GetProducts(Guid id)
    {
        return Ok();
    }
}
