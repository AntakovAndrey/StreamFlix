namespace ParsingService.Domain.Core;

public class Series:ParseResult
{
    public int Id { get; set; }
    public string Title { get; set; }
    public IEnumerable<SeriesTorrentLink> TorrentLinks { get; set; }
}