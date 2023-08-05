namespace Game.Services;

public interface IFileService
{

    /// <summary>
    /// Reads data from a CSV file and returns it as a list of dictionaries.
    /// </summary>
    /// <param name="fileName">The name of the CSV file to read.</param>
    /// <returns>A list of dictionaries representing the CSV data.</returns>
    public List<Dictionary<string, string>> ReadFromCsv(string fileName);


    /// <summary>
    /// Retrieves the content of a specified file.
    /// </summary>
    /// <param name="fileName">The name of the file to retrieve content from.</param>
    /// <returns>The content of the file as a string.</returns>
    public string GetFile(string fileName);

    /// <summary>
    /// Reads lines from a specified file and returns them as an array of strings.
    /// </summary>
    /// <param name="file">The content of the file as a string.</param>
    /// <returns>An array of strings representing lines from the file.</returns>
    public string[] ReadLinesFromFile(string file);

    /// <summary>
    /// Writes to the specified file with the contents given
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="contents"></param>
    public void WriteToFile(string fileName, string contents);

}
 