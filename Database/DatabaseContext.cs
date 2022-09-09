using DotnetApi.Models;
using Microsoft.EntityFrameworkCore;
namespace Dot6.API.Crud.Data;

public class DatabaseContext : DbContext
{
  public DatabaseContext(
      DbContextOptions<DatabaseContext> options
      ) : base(options)
  {
  }
  public DbSet<WeatherForecast> WeatherForecast { get; set; }
}