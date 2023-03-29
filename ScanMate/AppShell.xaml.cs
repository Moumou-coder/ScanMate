namespace ScanMate;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ChampionsPage), typeof(ChampionsPage));
        Routing.RegisterRoute(nameof(SkinsPage), typeof(SkinsPage));
    }
}
