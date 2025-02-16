using ParsingService.Domain.Core;
using ParsingService.Domain.Interfaces;
using ParsingService.Infrastructure.Data;

namespace ParsingService.Infrastructure.Parsers;

public class ParseResultService
{
    private readonly IMovieRepository _movieRepository;
    public ParseResultService(MovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task VerifyParseResult(IEnumerable<ParseResult> results)
    {
        return;
    }
}