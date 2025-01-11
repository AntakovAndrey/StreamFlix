namespace ParsingService.Domain.Core;

public class Movie:ParseResult
{
    public int Id { get; set; }
    public string Title { get; set; }
}