namespace ScanMate.Services;

public partial class ProfilService
{
    public ProfilService() { }

    List<Profil> profilList;

    public async Task<List<Profil>> GetProfilData()
    {
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ScanMateServer", "profildata.json");
        string jsonContent;

        // Read the file contents
        using (var stream = new FileStream(filePath, FileMode.Open))
        using (var reader = new StreamReader(stream))
            jsonContent = await reader.ReadToEndAsync();

        // Deserialize the JSON into a list of ProfilData
        profilList = JsonSerializer.Deserialize<List<Profil>>(jsonContent);

        // Return the filled list
        return profilList;
    }
}