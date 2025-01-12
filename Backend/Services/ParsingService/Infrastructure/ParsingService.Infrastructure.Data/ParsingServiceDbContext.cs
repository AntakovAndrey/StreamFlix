using Microsoft.EntityFrameworkCore;
using ParsingService.Domain.Core;

namespace ParsingService.Infrastructure.Data;

public class ParsingServiceDbContext:DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Series> Series { get; set; }
    public DbSet<MovieTorrentLink> MovieTorrentLinks { get; set; }
    public DbSet<SeriesTorrentLink> SeriesTorrentLinks { get; set; }

    public ParsingServiceDbContext(DbContextOptions<ParsingServiceDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}