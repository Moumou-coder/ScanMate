namespace ScanMate.ViewModel;

public partial class MainViewModel : ObservableObject
{
	[ObservableProperty]
	string myTitle = "League Of Legend V1.0";

    [RelayCommand]
    public async Task GoToChampionsPage()
    {
        await Shell.Current.GoToAsync(nameof(ChampionsPage));
    }
    
    [RelayCommand]
    public async Task GoToSkinsPage()
    {
        await Shell.Current.GoToAsync(nameof(SkinsPage));
    }
}