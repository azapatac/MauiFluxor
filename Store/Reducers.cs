namespace MauiFluxor.Store;

using Fluxor;
using MauiFluxor.Store.WeatherUseCase;

public static class Reducers
{
    [ReducerMethod]
    public static WeatherState ReduceFetchDataResultAction(WeatherState state, FetchDataResultAction action) => new WeatherState(isLoading: false, forecasts: action.Forecasts);

    [ReducerMethod(typeof(FetchDataAction))]
    public static WeatherState ReduceFetchDataAction(WeatherState state) => new WeatherState(isLoading: true, forecasts: null);
}