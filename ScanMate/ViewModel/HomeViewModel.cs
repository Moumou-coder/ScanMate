using System.Linq.Expressions;

namespace ScanMate.ViewModel;

public partial class HomeViewModel : BaseViewModel
{
    BarCodeService MyBarCodeService;

    [ObservableProperty]
    string myTitle = "League Of Legend V1.0";
    [ObservableProperty]
    string myID = "17254";

    ProfilService profilService;
    ObservableCollection<Profil> myProfilList { get; set; } = new();

    public HomeViewModel()
	{
        profilService = new ProfilService();
    }

    [RelayCommand]
    public async Task Scanner()
    {
        IsBusy = true;
        InitBarCodeService();

        try
        {
            Globals.StaticListProfil = await profilService.GetProfilData();
            foreach(Profil profil in Globals.StaticListProfil) { myProfilList.Add(profil); }
            // Find the matching profile based on MyID
            Profil matchingProfile = myProfilList.FirstOrDefault(profile => profile.Profil_ID == MyID);

            if (matchingProfile != null)
            {
                await Shell.Current.DisplayAlert("Profil", "trouvé ", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Profil", "pas trouvé ", "OK");
            }
        }
        catch (Exception ex) 
        {
            await Shell.Current.DisplayAlert("Scanner : ", ex.Message, "OK");
        }

        IsBusy = false;
    }

    internal void InitBarCodeService()
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
        try
        {
            await Shell.Current.GoToAsync(nameof(ChampionsPage));
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Navigation : ", ex.Message, "OK");
        }
    }

    [RelayCommand]
    public async Task GoToSkinsPage()
    {
        try
        {
            await Shell.Current.GoToAsync(nameof(SkinsPage));
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Navigation : ", ex.Message, "OK");
        }
    }

    //[RelayCommand]
    //public async Task GoToUserPage()
    //{
    //    await Shell.Current.GoToAsync(nameof(UserPage));
    //}
}