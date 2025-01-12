using Microsoft.AspNetCore.Mvc;

namespace ParsingService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ParsersController:Controller
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World!");
    }
}