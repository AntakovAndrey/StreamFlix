using ParsingService.Domain.Core;
using ParsingService.Domain.Interfaces;

namespace ParsingService.Infrastructure.Data;

public class MovieTorrentLinksRepository:IMovieTorrentLinksRepository
{
    private readonly ParsingServiceDbContext _dbContext;

    public MovieTorrentLinksRepository(ParsingServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public MovieTorrentLink GetMovieTorrentLinkById(int id)
    {
        return _dbContext.MovieTorrentLinks.Find(id);
    }

    public MovieTorrentLink GetMovieTorrentLinkByMovieId(int movieId)
    {
        return _dbContext.MovieTorrentLinks.FirstOrDefault(x => x.MovieId == movieId);
    }

    public IEnumerable<MovieTorrentLink> GetMovieTorrentLinks()
    {
        return _dbContext.MovieTorrentLinks;
    }

    public void AddMovieTorrentLink(MovieTorrentLink movie)
    {
        _dbContext.MovieTorrentLinks.Add(movie);
        _dbContext.SaveChanges();
    }

    public void UpdateMovieTorrentLink(MovieTorrentLink movie)
    {
        _dbContext.MovieTorrentLinks.Update(movie);
        _dbContext.SaveChanges();
    }

    public void DeleteMovieTorrentLink(int id)
    {
        _dbContext.MovieTorrentLinks.Remove(GetMovieTorrentLinkById(id));
        _dbContext.SaveChanges();
    }
}