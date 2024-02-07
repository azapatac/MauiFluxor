namespace MauiFluxor.ViewModels;

using Fluxor;
using MauiFluxor.Store.CounterUseCase;

public class DetailPageViewModel : BasePageViewModel
{
    private readonly IState<CounterState> CounterState;

    public string Message { get; set; } = string.Empty;

    public DetailPageViewModel(INavigationService navigationService, IState<CounterState> counterState) : base(navigationService)
    {
        CounterState = counterState;
    }

    public override void Initialize(INavigationParameters parameters)
    {        
        Message = $"You clicked {CounterState.Value.ClickCount} times.";
    }
}