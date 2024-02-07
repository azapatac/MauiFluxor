namespace MauiFluxor.ViewModels;

using Fluxor;
using MauiFluxor.Store.CounterUseCase;
using Prism.Navigation;

public partial class DetailPageViewModel : BasePageViewModel{

    public DetailPageViewModel(INavigationService navigationService, IStore store, IDispatcher dispatcher, IState<CounterState> counterState) : base(navigationService, store, dispatcher, counterState)
    {
    }

    public override void Initialize(INavigationParameters parameters)
    {        
        Message = $"You clicked {CounterState.Value.ClickCount} times.";
    }
}