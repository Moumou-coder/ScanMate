namespace ScanMate.View;

public partial class UserPage : ContentPage
{
	public UserPage(UserViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        
    }
}