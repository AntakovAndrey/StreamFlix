namespace ParsingService.Domain.Core;

public class MovieDto:ParseResult
{
    public string? Title { get; set; }
    public string? OriginalTitle { get; set; }
    public int ReleaseYear { get; set; }
    public byte[]? Image { get; set; }
    public string? Description { get; set; }
    public string[]? Genres { get; set; }
    public string? ParsedBy { get; set; }
    public string? ImdbId { get; set; }
    public string? KinopoiskId { get; set; }
    public IEnumerable<string>? TorrentLinks { get; set; }
}