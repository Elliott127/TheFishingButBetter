namespace Game.Services;

public class FileService: IFileService
{
    public List<Dictionary<string, string>> ReadFromCsv(string fileName)
    {
        List<Dictionary<string, string>> csvData = new();

        try
        {
            var file = GetFile(fileName);

            // Read all lines from the CSV file
            string[] lines = ReadLinesFromFile(file);

            if (lines.Length > 1)
            {
                // Get the header line
                string[] headers = lines[0].Split(',');

                // Process each row (excluding the header row)
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(',');

                    // Create a dictionary to map values to headers
                    Dictionary<string, string> rowData = new();

                    // Map each value to its corresponding header
                    for (int j = 0; j < headers.Length; j++)
                    {
                        // Ensure the value exists for the current header
                        if (j < values.Length)
                        {
                            rowData[headers[j]] = values[j];
                        }
                        else
                        {
                            rowData[headers[j]] = string.Empty;
                        }
                    }

                    // Add the row data to the CSV data list
                    csvData.Add(rowData);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while reading the CSV file: " + ex.Message);
        }

        return csvData;
    }
    public string GetFile(string fileName)
    {
        // Change the file name and extension accordingly
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        DirectoryInfo solutionDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(baseDirectory).FullName).FullName).Parent.Parent.Parent;

        string file = Directory.GetFiles(solutionDirectory.FullName, fileName, SearchOption.AllDirectories)[0];
        return file;
    }

    public string[] ReadLinesFromFile(string file)
    {
        return File.ReadAllLines(file);
    }
}
