using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ParsingService.Application.Interfaces;
using ParsingService.Domain.Core;
using ParsingService.Domain.Interfaces;
using ParsingService.Infrastructure.Data;
using ParsingService.Infrastructure.Parsers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ParsingServiceDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<IMovieTorrentLinksRepository, MovieTorrentLinksRepository>();
builder.Services.AddSingleton<IParsersContainer, ParsersContainer>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();



var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

var parserContainer = app.Services.GetRequiredService<IParsersContainer>();

parserContainer.RegisterParser(new TorrentByMoviesParser());

parserContainer.OnParserWorked += fff;

void fff(IParsersContainer sender, IEnumerable<ParseResult> results)
{
    foreach (var resultItem in results)
    {
        if(resultItem is Movie movie)
            Console.WriteLine($"Movie: {movie.Title} download link: {movie.MovieTorrentLinks.First()}");
    }
}

app.Run();