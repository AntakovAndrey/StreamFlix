

using System.Collections;

namespace MovieService.Domain.Core;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public List<MovieTorrentLink>? TorrentLinks { get; set; }

    public static Movie FromMovieDto(MovieDto movieDto)
    {
        return new Movie()
        {
            Title = movieDto.Title
        };
    }
}