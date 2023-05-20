namespace ScanMate.ViewModel;

public partial class RegisterViewModel : BaseViewModel
{
    [ObservableProperty]
    public string firstName;
    [ObservableProperty]
    public string lastName;
    [ObservableProperty]
    public string userName;
    [ObservableProperty] 
    public string password;

    public RegisterViewModel()
    {

    }

    [RelayCommand]
    public async Task GoToLoginPage()
    {
        IsBusy = true;

        try
        {
            await Shell.Current.GoToAsync(nameof(MainPage));
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Navigation", ex.Message, "OK");
        }
        
        IsBusy = false;
    }
}
