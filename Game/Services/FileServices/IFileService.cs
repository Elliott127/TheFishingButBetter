
namespace Game.Services;

public interface IFileService
{
    public string[] GetFile();
    public string[] ReadLinesFromFile(string file);
}
