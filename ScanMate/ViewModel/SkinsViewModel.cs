namespace ScanMate.ViewModel;

public partial class SkinsViewModel : ObservableObject
{
    
    [ObservableProperty]
    string url = "";
    [ObservableProperty]
    string championName = "";
    [ObservableProperty]
    string skinName = "";
    [ObservableProperty]
    string skinPrice = "";


    public SkinsService skinsService;
    public ObservableCollection<Skins> mySkinList { get; set; } = new();
    

    public SkinsViewModel(SkinsService mySkins)
    {
        this.skinsService = mySkins;
    }

    [RelayCommand]
    public async Task GetSkinsFromJSON()
    {
        try
        {
            Globals.StaticListSkins = await skinsService.GetSkins();
            foreach (Skins skin in Globals.StaticListSkins) { mySkinList.Add(skin); }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error : ", ex.Message, "OK");
        }

    }

    [RelayCommand]
    public async Task CheckEntriesValue()
    {
        bool allEntriesValid = !string.IsNullOrEmpty(Url) &&
                               !string.IsNullOrEmpty(ChampionName) &&
                               !string.IsNullOrEmpty(SkinName) &&
                               !string.IsNullOrEmpty(SkinName);

        if (!allEntriesValid)
        {
            await Shell.Current.DisplayAlert("Attention : ", "Veuillez complétez tous les champs svp ! ", "OK");
            return;
        }

        await UpdateJSONWithNewSkin();
    }

    public async Task UpdateJSONWithNewSkin()
    {
        // Create a new skin object and add it to the list
        Skins newSkin = new Skins { Image = Url, ChampionName = ChampionName, Name = SkinName, Price = SkinPrice };

        // Update the JSON file
        try
        {
            await skinsService.AddSkin(newSkin);
            mySkinList.Add(newSkin);    
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error : ", ex.Message, "OK");
        }

    }
}
