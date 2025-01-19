using System.IO.Compression;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using ParsingService.Application.Interfaces;
using ParsingService.Domain.Core;

namespace ParsingService.Infrastructure.Parsers;

public class TorrentByMoviesParser:IParser
{
    public string BaseUrl { get; } = "https://torrent.by";
    
    public async Task <IEnumerable<ParseResult>> ParseAsync()
    { 
        var web = new HtmlWeb
        {
            AutomaticDecompression = DecompressionMethods.GZip,
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36"
        };
        List<Movie> movies = new List<Movie>();
        for (int pageNumber = 0;pageNumber<5 ;pageNumber++)
        {
            HtmlDocument document = web.Load($"{BaseUrl}/films/?page={pageNumber}");
            var movieTables = document.DocumentNode.SelectNodes("//table[@id='torrents_table']");
            if(movieTables == null)
                break;
            List<HtmlNode> movieTableRows = new List<HtmlNode>();
            foreach (HtmlNode movieTable in movieTables)
            {
                foreach (var tableRow in movieTable.SelectNodes("tr").
                             Where(node=>node.Attributes["class"]?.Value == "ttable_col1" 
                             || node.Attributes["class"]?.Value == "ttable_col2"))
                {
                    string movieLink =tableRow.SelectNodes(".//td/a")
                        .Where(node=>node.Attributes["class"]?.Value!="dwnld"&&node.Attributes["class"]?.Value != "magnet")
                        .First().Attributes["href"]?.Value;
                    document=web.Load($"{BaseUrl}{movieLink}");
                    var title = document.DocumentNode
                        .SelectSingleNode("//h1").InnerText;
                    var linkBox = document.DocumentNode.SelectSingleNode("//table[@id='downloadbox']");
                    var link = linkBox.SelectSingleNode(".//tr//td//a[@rel='nofollow']").Attributes["href"]?.Value;
                    var links = new MovieTorrentLink[]
                    {
                        new MovieTorrentLink()
                        {
                            Link = $"{BaseUrl}{link}",
                        }
                    };
                    Movie movie = new Movie
                    {
                        ParsedAt = DateTime.Now,
                        Title = title,
                        MovieTorrentLinks = links,
                    };
                    movies.Add(movie);
                }
            }  
        }
        return movies;
    }
}