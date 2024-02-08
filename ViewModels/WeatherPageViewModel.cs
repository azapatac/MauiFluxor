namespace MauiFluxor.ViewModels;

using System.Collections.ObjectModel;
using Fluxor;
using MauiFluxor.Shared;
using MauiFluxor.Store;
using MauiFluxor.Store.WeatherUseCase;
using Prism.Navigation;

public class WeatherPageViewModel : BasePageViewModel
{
    private readonly IState<WeatherState> WeatherState;
    public ICollection<WeatherForecast> Weathers { get; set; }

    public WeatherPageViewModel(INavigationService navigationService, IDispatcher dispatcher,
        IState<WeatherState> state) : base(navigationService, dispatcher)
    {
        WeatherState = state;
        WeatherState.StateChanged += WeatherState_StateChanged;
    }

    public override void Initialize(INavigationParameters parameters)
    {
        var fetchDataAction = new FetchDataAction();
        Dispatcher.Dispatch(fetchDataAction);
    }

    private void WeatherState_StateChanged(object? sender, EventArgs e)
    {
        if (WeatherState.Value.Forecasts.Any())
        { 
            Weathers = new ObservableCollection<WeatherForecast>(WeatherState.Value.Forecasts);
        }
    }
}