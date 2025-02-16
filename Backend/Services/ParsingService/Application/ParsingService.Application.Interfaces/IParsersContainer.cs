using ParsingService.Domain.Core;

namespace ParsingService.Application.Interfaces;

public interface IParsersContainer
{
    public delegate void ParserWorkedDelegate(IParsersContainer sender, IEnumerable<ParseResult> parseResults);
    public event ParserWorkedDelegate? OnParserWorked;
    public void RegisterParser(IParser parser);
    public Task<IEnumerable<IParser>> GetParsers();
    public void StartParsers();
}