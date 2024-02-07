using CommunityToolkit.Mvvm.Input;

namespace MauiFluxor.ViewModels;

public partial class BasePageViewModel : BindableBase, IInitialize
{
    protected INavigationService NavigationService { get; set; }

    public BasePageViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
    }

    public virtual void Initialize(INavigationParameters parameters) { }

    [RelayCommand]
    public async Task Back()
    {
        await NavigationService.GoBackAsync();
    }
}