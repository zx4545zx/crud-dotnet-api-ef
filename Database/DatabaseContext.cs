using Microsoft.EntityFrameworkCore;
using DotnetApi.Models;

namespace DotnetApi.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(
        DbContextOptions<DatabaseContext> options
        ) : base(options) { }

    public DbSet<WeatherForecast> WeatherForecast { get; set; }
}
