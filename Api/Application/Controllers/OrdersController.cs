using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers;

[Route("api/orders")]
[ApiController]
public class OrdersController : ControllerBase
{
    [HttpPost]
    public IActionResult Create()
    {
        return Ok();
    }
}
