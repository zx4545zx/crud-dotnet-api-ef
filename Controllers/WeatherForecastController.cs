using Dot6.API.Crud.Data;
using DotnetApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly DatabaseContext _databaseContext;
    public WeatherForecastController(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    // url --> /WeatherForecast
    [HttpGet]
    public async Task<ActionResult<List<WeatherForecast>>> GetAll()
    {
        List<WeatherForecast>? weatherforecasts = await _databaseContext.WeatherForecast.ToListAsync();
        if (weatherforecasts == null) return NotFound();
        return Ok(weatherforecasts);
    }

    // url --> /WeatherForecast/1
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        WeatherForecast? weatherforecast = await _databaseContext.WeatherForecast.FindAsync(id);
        if (weatherforecast == null) return NotFound();
        return Ok(weatherforecast);
    }

    // url --> /WeatherForecast
    [HttpPost]
    public async Task<IActionResult> Post(WeatherForecast weatherforecast)
    {
        _databaseContext.WeatherForecast.Add(weatherforecast);
        int Id = await _databaseContext.SaveChangesAsync();
        if (Id == 0) return NotFound();
        return Created($"/WeatherForecast/{Id}", weatherforecast);
    }

    // url --> /WeatherForecast/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, WeatherForecast weatherforecast)
    {
        _databaseContext.WeatherForecast.Update(weatherforecast);
        int Id = await _databaseContext.SaveChangesAsync();
        if (Id == 0) return NotFound();
        return Ok(Id);
    }

    // url --> /WeatherForecast/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTModelById(int id)
    {
        WeatherForecast? weatherforecast = await _databaseContext.WeatherForecast.FindAsync(id);
        if (weatherforecast == null) return NotFound();

        _databaseContext.WeatherForecast.Remove(weatherforecast);
        await _databaseContext.SaveChangesAsync();
        return NoContent();
    }
}
