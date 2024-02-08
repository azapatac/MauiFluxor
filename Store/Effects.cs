namespace MauiFluxor.Store;

using Fluxor;
using MauiFluxor.Services;
using MauiFluxor.Shared;

public class Effects
{
    private readonly IWeatherForecastService WeatherForecastService;

    public Effects(IWeatherForecastService weatherForecastService)
    {
        WeatherForecastService = weatherForecastService;
    }

    [EffectMethod]
    public async Task HandleFetchDataAction(FetchDataAction action, IDispatcher dispatcher)
    {
        var forecasts = await WeatherForecastService.GetForecastAsync(DateTime.Now);
        dispatcher.Dispatch(new FetchDataResultAction(forecasts));
    }
}

public class FetchDataActionEffect : Effect<FetchDataAction>
{
    private readonly IWeatherForecastService WeatherForecastService;

    public FetchDataActionEffect(IWeatherForecastService weatherForecastService)
    {
        WeatherForecastService = weatherForecastService;
    }

    public override async Task HandleAsync(FetchDataAction action, IDispatcher dispatcher)
    {
        var forecasts = await WeatherForecastService.GetForecastAsync(DateTime.Now);
        dispatcher.Dispatch(new FetchDataResultAction(forecasts));
    }
}

public class FetchDataResultAction
{
    public IEnumerable<WeatherForecast> Forecasts { get; }

    public FetchDataResultAction(IEnumerable<WeatherForecast> forecasts)
    {
        Forecasts = forecasts;
    }
}