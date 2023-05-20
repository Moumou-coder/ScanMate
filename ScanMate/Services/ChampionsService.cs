namespace ScanMate.Services;

public partial class ChampionsService : ContentPage
{
	public ChampionsService() { }

    List<Champions> championsList;

    public async Task<List<Champions>> GetChampions()
    {

        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ScanMateServer", "championsdata.json");
        string jsonContent;

        // Read the file contents
        using var stream = new FileStream(filePath, FileMode.Open);
        using var reader = new StreamReader(stream);
        jsonContent = await reader.ReadToEndAsync();
        // Deserialize the JSON into a list of skins
        championsList = JsonSerializer.Deserialize<List<Champions>>(jsonContent);

        // Return the filled list
        return championsList;
    }
}