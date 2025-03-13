using MovieService.Domain.Core;
using MovieService.Domain.Interfaces;

namespace MovieService.Infrastructure.Data;

public class MovieTorrentLinkRepository:IMovieTorrentLinkRepository
{
    private readonly MovieServiceDbContext _dbContext;

    public MovieTorrentLinkRepository(MovieServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<MovieTorrentLink> GetMoviesTorrentLinks()
    {
        return _dbContext.MovieTorrentLinks.ToList();
    }

    public IEnumerable<MovieTorrentLink> GetByMovieId(int movieId)
    {
        return _dbContext.MovieTorrentLinks.Where(x => x.MovieId == movieId);
    }

    public MovieTorrentLink GetMovieTorrentLinkById(int id)
    {
        return _dbContext.MovieTorrentLinks.FirstOrDefault(x => x.MovieId == id);
    }

    public MovieTorrentLink AddMovieTorrentLink(MovieTorrentLink movie)
    {
        var result = _dbContext.MovieTorrentLinks.Add(movie);
        _dbContext.SaveChanges();
        return result.Entity;
    }

    public MovieTorrentLink UpdateMovieTorrentLink(MovieTorrentLink movie)
    {
        var result = _dbContext.MovieTorrentLinks.Update(movie);
        _dbContext.SaveChanges();
        return result.Entity;
    }

    public bool DeleteMovieTorrentLink(int id)
    {
        var filteredData = _dbContext.MovieTorrentLinks.Where(x => x.Id == id).FirstOrDefault();
        var result = _dbContext.Remove(filteredData);
        _dbContext.SaveChanges();
        return result != null ? true : false;
    }
}