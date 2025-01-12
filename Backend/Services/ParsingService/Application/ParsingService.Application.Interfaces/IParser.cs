using ParsingService.Domain.Core;

namespace ParsingService.Application.Interfaces;

public interface IParser
{
    public string BaseUrl { get; }
    public IEnumerable<ParseResult> Parse();
}