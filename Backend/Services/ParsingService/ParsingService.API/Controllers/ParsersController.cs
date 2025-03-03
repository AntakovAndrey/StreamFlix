using Microsoft.AspNetCore.Mvc;
using ParsingService.Application.Interfaces;
using ParsingService.Domain.Core;
using ParsingService.Infrastructure.RabbitMQ;

namespace ParsingService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ParsersController:Controller
{
    private readonly IParsersContainer _parsersContainer;
    private readonly IParseResultProducer _parseResultProducer;
    public ParsersController(IParsersContainer parsersContainer, IParseResultProducer parseResultProducer)
    {
        _parsersContainer = parsersContainer;
        _parseResultProducer = parseResultProducer;
        _parsersContainer.OnParserWorked += OnParserWorked;
    }
    
    
    private void OnParserWorked(IParsersContainer sender, IEnumerable<ParseResult> results)
    {
        foreach (var resultItem in results)
        {
            _parseResultProducer.SendMessage(resultItem);
        }
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