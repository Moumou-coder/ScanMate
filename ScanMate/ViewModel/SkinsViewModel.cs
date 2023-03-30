using ScanMate.Services;
namespace ScanMate.ViewModel;

public partial class SkinsViewModel : ObservableObject
{
    public SkinsService skinsService;
    public ObservableCollection<Skins> mySkinList { get; } = new();

    public SkinsViewModel(SkinsService mySkins)
    {
        this.skinsService = mySkins;
    }

    [RelayCommand]
    async Task GetSkinsFromJSON(string data)
    {
        try
        {
            Globals.StaticListSkins = await skinsService.GetSkins();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error : ", ex.Message, "OK");
        }

        foreach (Skins skin in Globals.StaticListSkins) { mySkinList.Add(skin); }
    }


}