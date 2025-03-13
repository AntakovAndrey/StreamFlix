using MovieService.Domain.Core;

namespace MovieService.Domain.Interfaces;

public interface IMovieTorrentLinkRepository
{
    public IEnumerable <MovieTorrentLink> GetMoviesTorrentLinks();
    public IEnumerable<MovieTorrentLink> GetByMovieId(int movieId);
    public MovieTorrentLink GetMovieTorrentLinkById(int id);
    public MovieTorrentLink AddMovieTorrentLink(MovieTorrentLink movie);
    public MovieTorrentLink UpdateMovieTorrentLink(MovieTorrentLink movie);
    public bool DeleteMovieTorrentLink(int id);
}