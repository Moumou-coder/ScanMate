namespace ScanMate.ViewModel;

[QueryProperty("Champion", "Champion")]
public partial class ChampionDetailsViewModel : ObservableObject
{

    [ObservableProperty]
    Champions champion;

    public ChampionDetailsViewModel()
    {

    }

}