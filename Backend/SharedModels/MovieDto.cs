namespace SharedModels;

public class MovieDto
{
    public string? Title { get; set; }
    public IEnumerable<string>? TorrentLinks { get; set; }
}