namespace MauiFluxor.ViewModels;

using CommunityToolkit.Mvvm.Input;
using Fluxor;
using MauiFluxor.Store.CounterUseCase;

public partial class BasePageViewModel : BindableBase, IInitialize
{
    protected readonly IDispatcher Dispatcher;
    protected readonly IState<CounterState> CounterState;
    protected readonly IStore Store;
    protected readonly INavigationService NavigationService;

    public string Message { get; set; } = string.Empty;

    public BasePageViewModel(INavigationService navigationService, IStore store, IDispatcher dispatcher, IState<CounterState> counterState)
    {
        NavigationService = navigationService;
        
        CounterState = counterState;
        CounterState.StateChanged += CounterState_StateChanged;
        Dispatcher = dispatcher;
        Store = store;
    }

    public virtual void Initialize(INavigationParameters parameters) { }


    [RelayCommand]
    public void Count()
    {
        var action = new IncrementCounterAction(1);
        Dispatcher.Dispatch(action);
    }

    protected void CounterState_StateChanged(object? sender, EventArgs e)
    {
        var count = CounterState.Value.ClickCount;

        if (count == 1)
            Message = $"Clicked {count} time";
        else
            Message = $"Clicked {count} times";
    }
}