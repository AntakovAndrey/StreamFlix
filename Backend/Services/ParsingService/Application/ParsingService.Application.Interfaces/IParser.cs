using ParsingService.Domain.Core;
using ParsingService.Domain.Core.Enums;

namespace ParsingService.Application.Interfaces;

public interface IParser
{
    public Guid Guid { get; set; }
    public string Name { get;}
    public string BaseUrl { get; }
    public ParserStatus Status { get; set; }
    public DateTime LastStarted { get; set; }
    public void ParseAsync();
    public event ParseHandler OnParse;
    public delegate void ParseHandler(IEnumerable<ParseResult> results);
    
    public void Start();
    protected Thread CurrentThread { get; set; }
}