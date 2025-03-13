using System.Text;
using System.Threading.Channels;
using Newtonsoft.Json;
using ParsingService.Domain.Core;
using RabbitMQ.Client;

namespace ParsingService.Infrastructure.RabbitMQ;

public class ParseResultProducer:IParseResultProducer
{
    private readonly RabbitMqConfiguration _rabbitMqConfiguration;
    private readonly IConnection _connection;
    private readonly ConnectionFactory _connectionFactory;
    private readonly IChannel _channel;
    
    public ParseResultProducer(RabbitMqConfiguration rabbitMqConfiguration)
    {
        _rabbitMqConfiguration = rabbitMqConfiguration;
        _connectionFactory = new ConnectionFactory()
        {
            HostName = _rabbitMqConfiguration.HostName ?? throw new InvalidOperationException(),
            UserName = _rabbitMqConfiguration.UserName ?? throw new InvalidOperationException(),
            Password = _rabbitMqConfiguration.Password ?? throw new InvalidOperationException()
        };
        _connection = _connectionFactory.CreateConnectionAsync().Result;
        _channel = _connection.CreateChannelAsync().Result;
        
    }
        
    public async Task SendMessage(ParseResult parseResult)
    {
        string json = string.Empty;
        if (parseResult is Series)
        {
            await _channel.QueueDeclareAsync(RabbitMqQueues.SeriesQueue, exclusive: false);
            json = JsonConvert.SerializeObject(parseResult as Series);
        }
        if (parseResult is Movie movie)
        {
            await _channel.QueueDeclareAsync(RabbitMqQueues.MovieQueue, exclusive: false,autoDelete: false);
            json = JsonConvert.SerializeObject(movie.ToMovieDto());
        }
        var body = Encoding.UTF8.GetBytes(json);
        await _channel.BasicPublishAsync("", routingKey: RabbitMqQueues.MovieQueue, body: body);
    }
}