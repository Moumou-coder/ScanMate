namespace ScanMate.ViewModel;

public partial class MainViewModel : ObservableObject
{
    BarCodeService MyBarCodeService;

    [ObservableProperty]
    string myTitle = "League Of Legend V1.0";
    [ObservableProperty]
    string myID ="Mister M";

    public MainViewModel()
    {
        this.MyBarCodeService = new BarCodeService();
        MyBarCodeService.ConfigureScanner();
        MyBarCodeService.SerialBuffer.Changed += SerialBuffer_Changed;
    }

    private void SerialBuffer_Changed(object sender, EventArgs e)
    {
        BarCodeService.QueueBuffer myQueue = (BarCodeService.QueueBuffer)sender;
        MyID = myQueue.Dequeue().ToString(); //ActiveTarget = nom du label a changer!!!!
    }

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

    [RelayCommand]
    public async Task GoToHomePage()
    {
        await Shell.Current.GoToAsync(nameof(HomePage));
    }
}
