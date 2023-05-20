using Microsoft.Extensions.Logging;

namespace ScanMate;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<HomeViewModel>();

        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<RegisterViewModel>();

        builder.Services.AddTransient<ChampionsPage>();
        builder.Services.AddTransient<ChampionsViewModel>();
        builder.Services.AddTransient<SkinsService>();

        builder.Services.AddTransient<SkinsPage>();
        builder.Services.AddTransient<SkinsViewModel>();
        builder.Services.AddTransient<ChampionsService>();

        builder.Services.AddTransient<ChampionDetailsPage>();
        builder.Services.AddTransient<ChampionDetailsViewModel>();

        builder.Services.AddTransient<UserPage>();
        builder.Services.AddTransient<UserViewModel>();

        return builder.Build();
	}
}
