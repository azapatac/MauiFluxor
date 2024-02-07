using CommunityToolkit.Mvvm.Input;

namespace MauiFluxor.ViewModels;

public class BasePageViewModel : BindableBase, IInitialize
{
    protected INavigationService NavigationService { get; set; }

    public BasePageViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
    }

    public virtual void Initialize(INavigationParameters parameters) { }
}