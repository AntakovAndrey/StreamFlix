using Microsoft.AspNetCore.Mvc;
using MovieService.Domain.Interfaces;

namespace MovieService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : Controller
{
    private readonly IMovieRepository _movieRepository;

    public MovieController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return Ok(_movieRepository.GetMovies());
    }

    [HttpGet("{message}")]
    public IActionResult Search(string message)
    {
        return Ok(_movieRepository.SearchMovie(message));
    }
}