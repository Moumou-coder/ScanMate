namespace ScanMate.View;

public partial class SkinsPage : TabbedPage
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

    protected override bool OnBackButtonPressed()
    {
        // If the current page is the second content page (AddNewSkin), 
        // switch to the first content page before navigating back.
        if (CurrentPage == Children[1])
        {
            CurrentPage = Children[0];
            return true;
        }

        return base.OnBackButtonPressed();
    }
}