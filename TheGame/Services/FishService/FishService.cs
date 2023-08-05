namespace Game.Services;

public class FishService : IFishService
{
    private readonly IFileService fileService;
    public FishService(IFileService fileService) 
    {
        this.fileService = fileService;
    }
    public List<Dictionary<string, string>> ReadFishFromCsv()
    {
        List<Dictionary<string, string>> csvData = new();

        try
        {
            var files = fileService.GetFile("Fishing.csv");

            // Select the matching file
            string file = files[0];

            // Read all lines from the CSV file
            string[] lines = fileService.ReadLinesFromFile(file);

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
}
