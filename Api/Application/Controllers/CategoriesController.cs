using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    [HttpPost]
    public IActionResult Create()
    {
        return Ok();
    }
}
