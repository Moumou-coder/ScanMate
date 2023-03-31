namespace ScanMate.View;

public partial class ChampionsPage : ContentPage
{
    private readonly ChampionsViewModel viewModel;

    public ChampionsPage(ChampionsViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.GetChampionsFromJSON();
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args) { base.OnNavigatedTo(args); }
}