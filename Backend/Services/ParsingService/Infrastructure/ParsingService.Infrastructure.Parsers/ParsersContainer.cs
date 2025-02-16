using ParsingService.Application.Interfaces;
using ParsingService.Domain.Core;
using ParsingService.Domain.Core.Enums;

namespace ParsingService.Infrastructure.Parsers;

public class ParsersContainer : IParsersContainer
{
    private readonly List<IParser> _parsers = [];
    
    public event IParsersContainer.ParserWorkedDelegate? OnParserWorked;

    public void RegisterParser(IParser parser)
    {
        if (parser == null) throw new ArgumentNullException(nameof(parser));
        parser.Guid = Guid.NewGuid();
        parser.Status = ParserStatus.Stopped;
        parser.OnParse += ParserWorked;
        _parsers.Add(parser);
    }

    public Task<IEnumerable<IParser>> GetParsers()
    {
        return Task.FromResult(_parsers.AsEnumerable());
    }
    public void StartParsers()
    {
        foreach (var parser in _parsers)
        {
            parser.Status = ParserStatus.Running;
            parser.LastStarted = DateTime.Now;
            parser.Start();
        }
    }

    private void ParserWorked(IEnumerable<ParseResult> parseResults)
    {
        if (OnParserWorked != null) OnParserWorked.Invoke(this, parseResults);
    }
}