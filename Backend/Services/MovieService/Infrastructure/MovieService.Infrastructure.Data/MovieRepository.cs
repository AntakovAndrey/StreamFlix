using Microsoft.EntityFrameworkCore;
using MovieService.Domain.Core;
using MovieService.Domain.Interfaces;

namespace MovieService.Infrastructure.Data;

public class MovieRepository:IMovieRepository
{
    private readonly MovieServiceDbContext _dbContext;

    public MovieRepository(MovieServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<Movie> GetMovies()
    {
        return _dbContext.Movies.Include(x=>x.TorrentLinks).ToList();
    }

    public IEnumerable<Movie> SearchMovie(string message)
    {
        List<Movie> result = new List<Movie>();
        foreach (var movie in _dbContext.Movies)
        {
            if(movie.Title.ToLower().Contains(message.ToLower()))
                result.Add(movie);
        }
        return result;
    }

    public Movie GetMovieById(int id)
    {
        return _dbContext.Movies.FirstOrDefault(m => m.Id == id);
    }

    public Movie AddMovie(Movie movie)
    {
        var result = _dbContext.Movies.Add(movie);
        _dbContext.SaveChanges();
        return result.Entity;
    }

    public Movie UpdateMovie(Movie movie)
    {
        var result = _dbContext.Movies.Update(movie);
        _dbContext.SaveChanges();
        return result.Entity;
    }

    public bool DeleteMovie(int id)
    {
        var filteredData = _dbContext.Movies.Where(x => x.Id == id).FirstOrDefault();
        var result = _dbContext.Remove(filteredData);
        _dbContext.SaveChanges();
        return result != null ? true : false;
    }
}