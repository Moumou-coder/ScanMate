namespace ScanMate.ViewModel;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    public string userName;
    [ObservableProperty] 
    public string password;

    public MainViewModel()
    {

    }

    [RelayCommand]
    public async Task GoToHomePage()
    {
        IsBusy = true;

        try
        {
            await Shell.Current.GoToAsync(nameof(HomePage));
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Navigation", ex.Message, "OK");
        }
        
        IsBusy = false;
    }
}
