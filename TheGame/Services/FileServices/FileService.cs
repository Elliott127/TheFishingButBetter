
namespace Game.Services;

public class FileService: IFileService
{
    public string[] GetFile()
    {
        string fileName = "Fishing.csv"; 

        // Change the file name and extension accordingly
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        DirectoryInfo solutionDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(baseDirectory).FullName).FullName).Parent.Parent.Parent;

        string[] files = Directory.GetFiles(solutionDirectory.FullName, fileName, SearchOption.AllDirectories);
        return files;
    }

    public string[] ReadLinesFromFile(string file)
    {
        return File.ReadAllLines(file);
    }
}
