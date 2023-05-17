namespace ScanMate.ViewModel;

[QueryProperty("Champion", "Champion")]
public partial class ChampionDetailsViewModel : BaseViewModel
{

    [ObservableProperty]
    Champions champion;

    public ChampionDetailsViewModel()
    {

    }

}