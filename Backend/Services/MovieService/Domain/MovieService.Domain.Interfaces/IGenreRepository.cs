using MovieService.Domain.Core;

namespace MovieService.Domain.Interfaces;

public interface IGenreRepository
{
    public IEnumerable <Genre> GetGenres();
    public Genre GetGenreById(int id);
    public Genre AddGenre(Genre genre);
    public Genre UpdateGenre(Genre genre);
    public bool DeleteGenre(int id);
}