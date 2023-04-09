namespace ScanMate;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ChampionsPage), typeof(ChampionsPage));
        Routing.RegisterRoute(nameof(SkinsPage), typeof(SkinsPage));
        Routing.RegisterRoute(nameof(ChampionDetailsPage), typeof(ChampionDetailsPage));
    }
}
