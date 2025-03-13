using Microsoft.EntityFrameworkCore;
using MovieService.Domain.Interfaces;
using MovieService.Infrastructure.Data;
using MovieService.Infrastructure.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieServiceDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IGenreRepository, GenreRepository>();
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<IMovieTorrentLinkRepository, MovieTorrentLinkRepository>();
builder.Services.AddTransient<RabbitMqConfiguration>(x => new RabbitMqConfiguration
{
    HostName = builder.Configuration["RabbitMQ:HostName"],
    UserName = builder.Configuration["RabbitMq:UserName"],
    Password = builder.Configuration["RabbitMq:Password"],
});
builder.Services.AddSingleton<MovieParseConsumer>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

var consumer = app.Services.GetRequiredService<MovieParseConsumer>();
await consumer.StartConsuming();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();