using Game.Services;

namespace UnitTests.Services;

public class FileServiceTests
{
    private readonly string fileName = "Fishing.csv";

    [Fact]
    public void Get_File_Should_Return_File_In_Directory()
    {
        // Arrange
        IFileService fileService = new FileService();

        // Act
        var listOfFiles = fileService.GetFile(fileName);

        //Assert
        listOfFiles.Should().NotBeEmpty();
    }

    [Fact]
    public void Read_Lines_From_File_Should_Return_String_Array()
    {
        // Arrange
        IFileService fileService = new FileService();
        var file = fileService.GetFile(fileName);

        // Act
        var listOfFish = fileService.ReadLinesFromFile(file);

        // Assert
        listOfFish.Should().NotBeEmpty();
        listOfFish[1].Should().Contain("King George Whiting");
    }

    [Fact]
    public void Should_Have_Successfully_Read_From_CSV()
    {
        // Arrange
        IFileService fileService = new FileService();

        // Act
        List<Dictionary<string, string>> list = fileService.ReadFromCsv(fileName);

        // Assert
        list.Should().NotBeNullOrEmpty();
    }
}
