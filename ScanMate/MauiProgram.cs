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

        builder.Services.AddTransient<ChampionsPage>();
        builder.Services.AddTransient<ChampionsViewModel>();
        builder.Services.AddTransient<SkinsPage>();
        builder.Services.AddTransient<SkinsViewModel>();

		builder.Services.AddTransient<SkinsService>();

        return builder.Build();
	}
}
