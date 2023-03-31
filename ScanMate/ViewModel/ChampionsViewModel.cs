namespace ScanMate.ViewModel;


public partial class ChampionsViewModel : ObservableObject
{
    public ChampionsService championsService;
    public ObservableCollection<Champions> myChampionList { get; } = new();

    public ChampionsViewModel(ChampionsService myChampions)
    {
        this.championsService = myChampions;
    }

    [RelayCommand]
    public async Task GetChampionsFromJSON()
    {
        try
        {
            Globals.StaticListChampions = await championsService.GetChampions();
            foreach (Champions champion in Globals.StaticListChampions) { myChampionList.Add(champion); }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error : ", ex.Message, "OK");
        }

    }

}