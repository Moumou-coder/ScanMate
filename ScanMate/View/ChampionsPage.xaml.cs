namespace ScanMate.View;

public partial class ChampionsPage : ContentPage
{
	public ChampionsPage(ChampionsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}