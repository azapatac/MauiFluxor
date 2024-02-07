namespace MauiFluxor.ViewModels;

using CommunityToolkit.Mvvm.Input;
using Fluxor;
using MauiFluxor.Store.CounterUseCase;
using Prism.Navigation;

public partial class MainPageViewModel : BasePageViewModel
{
    private readonly IStore Store;
    private readonly IDispatcher Dispatcher;
    private readonly IState<CounterState> CounterState;

    public string Message { get; set; } = "Click me";

    public MainPageViewModel(INavigationService navigationService, IStore store, IDispatcher dispatcher, IState<CounterState> counterState) : base(navigationService)
    {
        CounterState = counterState;
        CounterState.StateChanged += CounterState_StateChanged;
        Dispatcher = dispatcher;
        Store = store;
    }

    public override void Initialize(INavigationParameters parameters)
    {
        Store.InitializeAsync().Wait();
    }

    [RelayCommand]
    public void Count()
    {
        var action = new IncrementCounterAction();
        Dispatcher.Dispatch(action);
    }

    [RelayCommand]
    public async Task Navigate()
    {
        await NavigationService.NavigateAsync("Detail");
    }

    private void CounterState_StateChanged(object? sender, EventArgs e)
    {
        var count = CounterState.Value.ClickCount;

        if (count == 1)
            Message = $"Clicked {count} time";
        else
            Message = $"Clicked {count} times";
    }
}