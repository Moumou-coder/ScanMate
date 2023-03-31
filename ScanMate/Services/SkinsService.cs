namespace ScanMate.Services;

public class SkinsService : ContentPage
{
    public SkinsService() { }

    List<Skins> skinsList;
    public async Task<List<Skins>> GetSkins()
    {

        using var stream = await FileSystem.OpenAppPackageFileAsync("SkinsData.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        skinsList = JsonSerializer.Deserialize<List<Skins>>(contents);

        return skinsList;
    }
}

