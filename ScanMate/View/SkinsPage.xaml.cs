namespace ScanMate.View;

public partial class SkinsPage : ContentPage
{
    private readonly SkinsViewModel viewModel;

	public SkinsPage(SkinsViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;

	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.GetSkinsFromJSON();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}