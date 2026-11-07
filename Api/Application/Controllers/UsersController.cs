using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    public IActionResult Create()
    {
        return Ok();
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok();
    }

    [HttpGet("{id:guid}/orders")]
    public IActionResult GetOrders(Guid id)
    {
        return Ok();
    }
}
