
namespace Game.Services;

public interface IFileService
{
    public string[] GetFile(string fileName);
    public string[] ReadLinesFromFile(string file);
}
