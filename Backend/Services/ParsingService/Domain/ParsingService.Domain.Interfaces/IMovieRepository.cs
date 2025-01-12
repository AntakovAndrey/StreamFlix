using ParsingService.Domain.Core;

namespace ParsingService.Domain.Interfaces;

public interface IMovieRepository
{
    public Movie GetMovieById(int id);
    public IEnumerable<Movie> GetMovies();
    public void AddMovie(Movie movie);
    public void UpdateMovie(Movie movie);
    public void DeleteMovie(int id);
}