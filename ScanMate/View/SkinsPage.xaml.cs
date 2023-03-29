namespace ScanMate.View;

public partial class SkinsPage : ContentPage
{
	public SkinsPage(SkinsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}