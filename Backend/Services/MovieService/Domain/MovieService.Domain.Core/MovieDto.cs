namespace MovieService.Domain.Core;

public class MovieDto
{
    public string? Title { get; set; }
    public IEnumerable<string>? TorrentLinks { get; set; }
}