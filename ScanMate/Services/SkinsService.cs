namespace ScanMate.Services;

public class SkinsService : ContentPage
{
    public SkinsService() { }

    List<Skins> skinsList;

    public async Task<List<Skins>> GetSkins()
    {

        using var stream = await FileSystem.OpenAppPackageFileAsync("skinsdata.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        skinsList = JsonSerializer.Deserialize<List<Skins>>(contents);

        return skinsList;
    }

    public async Task<List<Skins>> AddSkin(Skins newSkin)
    {
        // Read the file contents
        using var stream = await FileSystem.OpenAppPackageFileAsync("skinsdata.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();

        // Deserialize the JSON into a list of skins
        skinsList = JsonSerializer.Deserialize<List<Skins>>(contents);

        // Add the new skin to the list
        skinsList.Add(newSkin);

        // Serialize the updated list to a JSON string
        var updatedJsonString = JsonSerializer.Serialize(skinsList);

        // Write the file content to the app data directory
        string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "skinsdata.json");
        using FileStream outputStream = File.OpenWrite(targetFile);
        using StreamWriter streamWriter = new(outputStream);
        await streamWriter.WriteAsync(updatedJsonString);

        return skinsList;
    }

}

