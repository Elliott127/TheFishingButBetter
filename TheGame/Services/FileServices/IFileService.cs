namespace Game.Services;

public interface IFileService
{
    public List<Dictionary<string, string>> ReadFromCsv(string fileName);
    public string GetFile(string fileName);
    public string[] ReadLinesFromFile(string file);
}
