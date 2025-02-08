namespace ParsingService.Domain.Core;

public class Movie:ParseResult
{
    public int Id { get; set; }
    public string Title { get; set; }
    public IEnumerable<MovieTorrentLink> MovieTorrentLinks { get; set; }
    public override string ToString()
    {
        return $"{Title} {MovieTorrentLinks.First().Link}";
    }
}