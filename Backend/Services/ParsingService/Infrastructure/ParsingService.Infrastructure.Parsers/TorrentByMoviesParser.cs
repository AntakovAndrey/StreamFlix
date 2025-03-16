using System.IO.Compression;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using ParsingService.Application.Interfaces;
using ParsingService.Domain.Core;
using ParsingService.Domain.Core.Enums;

namespace ParsingService.Infrastructure.Parsers;

public class TorrentByMoviesParser:IParser
{
    public Guid Guid { get; set; }
    public string Name { get; } = "TorrentByMoviesParser";
    public string BaseUrl { get; } = "https://torrent.by";
    public ParserStatus Status { get; set; }
    public DateTime LastStarted { get; set; }
    private MovieDto ParseMoviePage(string url)
    {
        var web = new HtmlWeb
        {
            AutomaticDecompression = DecompressionMethods.GZip,
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36"
        };
        var currentMoviePage = web.Load(url);
        
        
        
        var title = currentMoviePage.DocumentNode.SelectSingleNode("//h1").InnerText;
        var descriptionContainer = currentMoviePage.DocumentNode.SelectNodes("//div[contains(@class,'descr')]//a");
        string imdbId="", kinopoiskId="";
        
        //Parsing kinopoisk and imdb IDs
        #region imdb and kinopoisk id
        
        foreach (var titleNode in descriptionContainer)
        {
            if (titleNode.Attributes["href"].Value.Contains("imdb.com/title/"))
            {
                Regex imdbRegex = new Regex("title/tt\\d+");
                var r  = imdbRegex.Matches(titleNode.Attributes["href"].Value);
                foreach (Match a in r)
                {
                    imdbId= a.Value.Split('/').Last();
                    break;  
                }
            }
            if (titleNode.Attributes["href"].Value.Contains("kinopoisk.ru/"))
            {
                Regex kinopoiskRegex = new Regex("film/\\d+");
                var r  = kinopoiskRegex.Matches(titleNode.Attributes["href"].Value);
                foreach (Match a in r)
                {
                    kinopoiskId= a.Value.Split('/').Last();
                    break;  
                }
            }
        }
        
        #endregion
        
        var linkBox = currentMoviePage.DocumentNode.SelectSingleNode("//table[@id='downloadbox']");
        var link = linkBox.SelectSingleNode(".//tr//td//a[@rel='nofollow']").Attributes["href"]?.Value;
        var links = new MovieTorrentLink[]
        {
            new MovieTorrentLink()
            {
                Link = $"{BaseUrl}{link}",
            }
        };
        MovieDto movieDto = new MovieDto()
        {
            ParsedAt = DateTime.Now,
            Title = title,
            ImdbId = imdbId,
            KinopoiskId = kinopoiskId,
        };
        return movieDto;
    }
    
    public void ParseAsync()
    { 
        var web = new HtmlWeb
        {
            AutomaticDecompression = DecompressionMethods.GZip,
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36"
        };
        for (int pageNumber = 0; ;pageNumber++)
        {
            HtmlDocument document = web.Load($"{BaseUrl}/films/?page={pageNumber}");
            var movieTables = document.DocumentNode.SelectNodes("//table[@id='torrents_table']");
            if(movieTables == null)
                break;
            foreach (HtmlNode movieTable in movieTables)
            {
                foreach (var tableRow in movieTable.SelectNodes("tr").
                             Where(node=>node.Attributes["class"]?.Value == "ttable_col1" 
                             || node.Attributes["class"]?.Value == "ttable_col2"))
                {
                    string movieLink =tableRow.SelectNodes(".//td/a")
                        .Where(node=>node.Attributes["class"]?.Value!="dwnld"&&node.Attributes["class"]?.Value != "magnet")
                        .First().Attributes["href"]?.Value;
                    MovieDto movie = ParseMoviePage($"{BaseUrl}{movieLink}");
                    OnParse.Invoke([movie]);
                }
            }  
        }
        
    }

    public event IParser.ParseHandler OnParse;

    public void Start()
    {
        this.CurrentThread=new Thread(ParseAsync);
        CurrentThread.Start();
    }

    public Thread CurrentThread { get; set; }
}