using MovieService.Domain.Core;

namespace MovieService.Domain.Interfaces;

public interface IMovieRepository
{
    public IEnumerable <Movie> GetMovies();
    public IEnumerable<Movie> SearchMovie(string message);
    public Movie GetMovieById(int id);
    public Movie AddMovie(Movie movie);
    public Movie UpdateMovie(Movie movie);
    public bool DeleteMovie(int id);
}