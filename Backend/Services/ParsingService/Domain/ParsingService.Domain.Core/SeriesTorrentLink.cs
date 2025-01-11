namespace ParsingService.Domain.Core;

public class SeriesTorrentLink
{
    public int Id { get; set; }
    public string Link { get; set; }
    public int Season { get; set; }
    public int EpisodeStart { get; set; }
    public int EpisodeEnd { get; set; }
    public int SeriesId { get; set; }
}