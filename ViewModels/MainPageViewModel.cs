namespace MauiFluxor.ViewModels;

using CommunityToolkit.Mvvm.Input;
using Fluxor;
using MauiFluxor.Store.CounterUseCase;
using Prism.Navigation;

public partial class MainPageViewModel : BasePageViewModel
{
    public MainPageViewModel(INavigationService navigationService, IStore store, IDispatcher dispatcher, IState<CounterState> counterStat) : base(navigationService, store, dispatcher, counterStat)
    {
        Message = "Click me";
    }

    public override void Initialize(INavigationParameters parameters)
    {
        Store.InitializeAsync().Wait();
    }

    [RelayCommand]
    public async Task Navigate()
    {
        await NavigationService.NavigateAsync("Detail");
    }
}