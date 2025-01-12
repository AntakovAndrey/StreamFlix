using ParsingService.Domain.Core;

namespace ParsingService.Domain.Interfaces;

public interface IMovieTorrentLinksRepository
{
    public MovieTorrentLink GetMovieTorrentLinkById(int id);
    public MovieTorrentLink GetMovieTorrentLinkByMovieId(int movieId);
    public IEnumerable<MovieTorrentLink> GetMovieTorrentLinks();
    public void AddMovieTorrentLink(MovieTorrentLink movie);
    public void UpdateMovieTorrentLink(MovieTorrentLink movie);
    public void DeleteMovieTorrentLink(int id);
}