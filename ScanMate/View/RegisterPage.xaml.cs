namespace ScanMate.View;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel viewmodel)
	{
		InitializeComponent();
        BindingContext = viewmodel;
    }
} 