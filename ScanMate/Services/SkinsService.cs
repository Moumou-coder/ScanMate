namespace ScanMate.Services;

public class SkinsService : ContentPage
{
    public SkinsService() { }

    List<Skins> skinsList;

    public async Task<List<Skins>> GetSkins()
    {

        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ScanMateServer", "skinsdata.json");
        string jsonContent;

        // Read the file contents
        using var stream = new FileStream(filePath, FileMode.Open);
        using var reader = new StreamReader(stream);
        jsonContent = await reader.ReadToEndAsync();
        // Deserialize the JSON into a list of skins
        skinsList = JsonSerializer.Deserialize<List<Skins>>(jsonContent);

        // Return the filled list
        return skinsList;
    }

    public async Task<List<Skins>> AddSkin(Skins newSkin)
    {
        // Add the new skin to the list
        skinsList.Add(newSkin);

        // Serialize the updated list to a JSON string
        var updatedJsonString = JsonSerializer.Serialize(skinsList);

        // Write the file content to the app data directory
        string targetFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ScanMateServer", "skinsdata.json");
        using FileStream outputStream = File.OpenWrite(targetFile);
        using StreamWriter streamWriter = new(outputStream);
        await streamWriter.WriteAsync(updatedJsonString);

        return skinsList;
    }


    public async Task<List<Skins>> DeleteSkin(Skins skin)
    {
        // Supprimer le skin de la liste
        skinsList.Remove(skin);

        // Serialize the updated list to a JSON string
        var updatedJsonString = JsonSerializer.Serialize(skinsList);

        // Write the file content to the app data directory
        string targetFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ScanMateServer", "skinsdata.json");
        await File.WriteAllTextAsync(targetFile, updatedJsonString);

        return skinsList;
    }

}

