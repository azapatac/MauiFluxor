namespace MauiFluxor.Services;

using MauiFluxor.Shared;

public interface IWeatherForecastService
{
    Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
}

public class WeatherForecastService : IWeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
        // Simulate a 1 second response time
        await Task.Delay(1000);

        var random = new Random();
        return Enumerable.Range(1, 2).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = random.Next(-20, 55),
            Summary = Summaries[random.Next(Summaries.Length)]
        }).ToArray();
    }
}