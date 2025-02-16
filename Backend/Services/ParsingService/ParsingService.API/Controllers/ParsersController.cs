using Microsoft.AspNetCore.Mvc;
using ParsingService.Application.Interfaces;

namespace ParsingService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ParsersController:Controller
{
    private readonly IParsersContainer _parsersContainer;
    public ParsersController(IParsersContainer parsersContainer)
    {
        _parsersContainer = parsersContainer;
    }
    
    [HttpGet("GetParsers")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _parsersContainer.GetParsers());
    }

    [HttpGet("RunParsers")]
    public async Task<IActionResult> RunParsers()
    {
        _parsersContainer.StartParsers();
        return Ok();
    }
}