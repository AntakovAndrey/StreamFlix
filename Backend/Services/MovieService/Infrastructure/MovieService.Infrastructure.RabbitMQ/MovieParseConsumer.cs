using System.Text;
using System.Text.Json;
using MovieService.Domain.Core;
using MovieService.Domain.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MovieService.Infrastructure.RabbitMQ;

public class MovieParseConsumer
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMovieTorrentLinkRepository _torrentLinkRepository;
    private readonly RabbitMqConfiguration _rabbitMqConfiguration;
    
    public MovieParseConsumer(RabbitMqConfiguration rabbitMqConfiguration,IMovieTorrentLinkRepository movieTorrentLinkRepository, IMovieRepository movieRepository)
    {
        _rabbitMqConfiguration = rabbitMqConfiguration;
        _movieRepository = movieRepository;
        _torrentLinkRepository = movieTorrentLinkRepository;
    }

    public async Task StartConsuming()
    {
        var factory = new ConnectionFactory {
            HostName = _rabbitMqConfiguration.HostName,
            UserName = _rabbitMqConfiguration.UserName,
            Password = _rabbitMqConfiguration.Password,
        };
        var connection = await factory.CreateConnectionAsync();
        var channel = await connection.CreateChannelAsync();
        try
        {
            await channel.QueueDeclareAsync("movieParseResultQueue",exclusive: false, durable: false, autoDelete: false);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += async (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            MovieDto movieDto = JsonSerializer.Deserialize<MovieDto>(body);
            Movie movie = Movie.FromMovieDto(movieDto);
            var addedMovie = _movieRepository.AddMovie(movie);
            foreach (var link in movieDto.TorrentLinks)
            {
                _torrentLinkRepository.AddMovieTorrentLink(new MovieTorrentLink()
                {
                    Link = link,
                    MovieId = addedMovie.Id
                });
            }
        };
        await channel.BasicConsumeAsync(queue:"movieParseResultQueue",autoAck:true,consumer:consumer);
    }
}