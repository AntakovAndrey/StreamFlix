using ParsingService.Domain.Core;
using ParsingService.Domain.Interfaces;

namespace ParsingService.Infrastructure.Data;

public class MovieRepository:IMovieRepository
{
    ParsingServiceDbContext _dbContext;
    
    public MovieRepository(ParsingServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Movie GetMovieById(int id)
    {
        return _dbContext.Movies.Find(id);
    }

    public IEnumerable<Movie> GetMovies()
    {
        return _dbContext.Movies;
    }

    public void AddMovie(Movie movie)
    {
        _dbContext.Movies.Add(movie);
        _dbContext.SaveChanges();
    }

    public void UpdateMovie(Movie movie)
    {
        _dbContext.Movies.Update(movie);
        _dbContext.SaveChanges();
    }

    public void DeleteMovie(int id)
    {
        _dbContext.Movies.Remove(GetMovieById(id));
        _dbContext.SaveChanges();
    }
}