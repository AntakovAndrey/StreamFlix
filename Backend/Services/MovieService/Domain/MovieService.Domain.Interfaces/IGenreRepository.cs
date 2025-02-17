using MovieService.Domain.Core;

namespace MovieService.Domain.Interfaces;

public interface IGenreRepository
{
    public IEnumerable <Genre> GetGenres();
    public Genre GetGenreById(int id);
    public Genre AddProduct(Genre product);
    public Genre UpdateProduct(Genre product);
    public bool DeleteProduct(int id);
}