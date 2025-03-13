using MovieService.Domain.Core;
using MovieService.Domain.Interfaces;

namespace MovieService.Infrastructure.Data;

public class GenreRepository:IGenreRepository 
{
    private readonly MovieServiceDbContext _dbContext;

    public GenreRepository(MovieServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<Genre> GetGenres()
    {
        return _dbContext.Genres.ToList();
    }

    public Genre GetGenreById(int id)
    {
        return _dbContext.Genres.FirstOrDefault(x => x.Id == id);
    }

    public Genre AddGenre(Genre product)
    {
        var result = _dbContext.Genres.Add(product);
        _dbContext.SaveChanges();
        return result.Entity;
    }

    public Genre UpdateGenre(Genre product)
    {
        var result = _dbContext.Genres.Update(product);
        _dbContext.SaveChanges();
        return result.Entity;
    }

    public bool DeleteGenre(int id)
    {
        var filteredData = _dbContext.Genres.Where(x => x.Id == id).FirstOrDefault();
        var result = _dbContext.Remove(filteredData);
        _dbContext.SaveChanges();
        return result != null ? true : false;
    }
}