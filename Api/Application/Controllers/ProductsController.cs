using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    [HttpPost]
    public IActionResult Create()
    {
        return Ok();
    }
}
