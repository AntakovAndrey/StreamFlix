using Microsoft.EntityFrameworkCore;
using ParsingService.Application.Interfaces;
using ParsingService.Domain.Core;
using ParsingService.Infrastructure.Parsers;
using ParsingService.Infrastructure.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<ParsingServiceDbContext>(options => 
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<RabbitMqConfiguration>(x => new RabbitMqConfiguration {
        HostName = builder.Configuration["RabbitMQ:HostName"],
        UserName = builder.Configuration["RabbitMQ:UserName"],
        Password = builder.Configuration["RabbitMQ:Password"]
});
builder.Services.AddTransient<IParseResultProducer, ParseResultProducer>();
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

app.Run();