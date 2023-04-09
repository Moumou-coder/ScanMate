namespace ScanMate.View;

public partial class ChampionDetailsPage : ContentPage
{
    public ChampionDetailsPage(ChampionDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}