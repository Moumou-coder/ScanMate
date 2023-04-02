using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace ScanMate.ViewModel;

public partial class SkinsViewModel : ObservableObject
{
    
    [ObservableProperty]
    string url;
    [ObservableProperty]
    string championName;
    [ObservableProperty]
    string skinName;
    [ObservableProperty]
    int skinPrice;
    [ObservableProperty]
    bool isAddButtonEnabled = true;
    [ObservableProperty]


    public SkinsService skinsService;
    public ObservableCollection<Skins> mySkinList { get; } = new();
    

    public SkinsViewModel(SkinsService mySkins)
    {
        this.skinsService = mySkins;
    }

    public void GetNewSkin()
    {
        // Access entry values and use them as needed
        string url = Url;
        string championName = ChampionName;
        string skinName = SkinName;
        int price = SkinPrice;
    }

    public void CreateNewSkin()
    {
        Skins newSkin = new Skins
        {
            Image = Url,
            ChampionName = ChampionName,
            Name = SkinName,
            Price = SkinPrice
        };

        mySkinList.Add(newSkin);
    }

    [RelayCommand]
    public void CheckEntriesValue()
    {
        bool allEntriesValid = !string.IsNullOrEmpty(Url) &&
                               !string.IsNullOrEmpty(ChampionName) &&
                               !string.IsNullOrEmpty(SkinName) &&
                               SkinPrice > 0;

        if (!allEntriesValid)
        {
            DisableAddButton();
        }

        IsAddButtonEnabled = allEntriesValid;
        OnPropertyChanged(nameof(IsAddButtonEnabled));
        GetNewSkin();
    }

    private void DisableAddButton()
    {
        IsAddButtonEnabled = false;
        OnPropertyChanged(nameof(IsAddButtonEnabled));
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

    private async Task AddSkinToJson(Skins newSkin)
    {
        try
        {
            // Read the existing JSON file into a string
            string jsonString = await File.ReadAllTextAsync("skinsdata.json");

            // Deserialize the JSON string into a list of objects
            List<Skins> skinsList = JsonConvert.DeserializeObject<List<Skins>>(jsonString);

            // Add the new object to the list
            skinsList.Add(newSkin);

            // Serialize the updated list back into a JSON string
            string updatedJsonString = JsonConvert.SerializeObject(skinsList, Formatting.Indented);

            // Write the JSON string back to the file
            await File.WriteAllTextAsync("skinsdata.json", updatedJsonString);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error : ", ex.Message, "OK");
        }
    }

}