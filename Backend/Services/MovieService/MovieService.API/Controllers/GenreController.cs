using Microsoft.AspNetCore.Mvc;
using MovieService.Domain.Core;
using MovieService.Domain.Interfaces;

namespace MovieService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreController : Controller
{
    private readonly IGenreRepository _genreRepository;

    public GenreController(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_genreRepository.GetGenres());
    }

    [HttpPost]
    public IActionResult Post(Genre genre)
    {
        var result = this._genreRepository.AddGenre(genre);
        return Ok(result);
    }
}