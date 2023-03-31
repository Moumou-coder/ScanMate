namespace ScanMate.Services;

public partial class ChampionsService : ContentPage
{
	public ChampionsService() { }

    List<Champions> championsList;
    public async Task<List<Champions>> GetChampions()
    {

        using var stream = await FileSystem.OpenAppPackageFileAsync("ChampionsData.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        championsList = JsonSerializer.Deserialize<List<Champions>>(contents);

        return championsList;
    }
}