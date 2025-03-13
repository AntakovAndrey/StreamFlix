using ParsingService.Domain.Core;

namespace ParsingService.Infrastructure.RabbitMQ;

public interface IParseResultProducer
{
    public Task SendMessage(ParseResult parseResult);
}