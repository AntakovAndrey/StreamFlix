namespace MovieService.Domain.Core;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? OriginalTitle { get; set; }
    public int ReleaseYear { get; set; }
}