namespace MovieService.Domain.Core;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImdbId { get; set; }
    public string? KinopoiskId { get; set; }
    public List<MovieTorrentLink>? TorrentLinks { get; set; }

    public static Movie FromMovieDto(MovieDto movieDto)
    {
        return new Movie()
        {
            ImdbId = movieDto.ImdbId,
            KinopoiskId = movieDto.KinopoiskId,
            Title = movieDto.Title,
            Description = movieDto.Description,
        };
    }
}