using Microsoft.AspNetCore.Mvc;

namespace MovieService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok();
    }
}