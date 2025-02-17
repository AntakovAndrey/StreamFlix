using Microsoft.EntityFrameworkCore;
using MovieService.Domain.Core;

namespace MovieService.Infrastructure.Data;

public class MovieServiceDbContext:DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    
    public MovieServiceDbContext(DbContextOptions<MovieServiceDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}