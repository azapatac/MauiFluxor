namespace MauiFluxor.Store.WeatherUseCase;

using System;
using Fluxor;
using MauiFluxor.Shared;

[FeatureState]
public class WeatherState
{
    public bool IsLoading { get; }
    public IEnumerable<WeatherForecast> Forecasts { get; }

    private WeatherState() { } // Required for creating initial state

    public WeatherState(bool isLoading, IEnumerable<WeatherForecast> forecasts)
    {
        IsLoading = isLoading;
        Forecasts = forecasts ?? Array.Empty<WeatherForecast>();
    }
}