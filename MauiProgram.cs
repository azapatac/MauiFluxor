using Fluxor;
using MauiFluxor.ViewModels;

namespace MauiFluxor;

public static class MauiProgram
{
    private const string Main = "MainPage";
    private const string Navigation = "NavigationPage";

    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UsePrism((prism) =>
            {
                prism.RegisterTypes(container =>
                {
                    container.RegisterForNavigation<DetailPage, DetailPageViewModel>("Detail");
                    container.RegisterForNavigation<MainPage, MainPageViewModel>(Main);
                    container.RegisterForNavigation<NavigationPage>(Navigation);
                })
                .OnAppStart(async app =>
                {                    
                    var res = await app.NavigateAsync($"{Navigation}/{Main}");                    
                });
            })
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .Services.AddFluxor(config =>
            {
                config.ScanAssemblies(typeof(MauiProgram).Assembly);
                config.WithLifetime(StoreLifetime.Singleton);
            });

		return builder.Build();
	}
}