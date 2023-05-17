namespace ScanMate.ViewModel;

public partial class MainViewModel : BaseViewModel
{
    public MainViewModel()
    {

    }

    [RelayCommand]
    public async Task GoToHomePage()
    {
        await Shell.Current.GoToAsync(nameof(HomePage));
    }
}
