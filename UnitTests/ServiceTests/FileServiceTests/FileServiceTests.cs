using Game.Services;
namespace UnitTests.Services;

public class FileServiceTests
{
    private readonly IFileService mockedFileService;

    public FileServiceTests()
    {
        mockedFileService = A.Fake<IFileService>();
    }

    [Fact]
    public void Get_File_Should_Return_File_In_Directory()
    {
        // Arrange
        string[] fileNames = new string[]
        {
            "foo.csv",
            "bar.csv"
        };
        A.CallTo(() => mockedFileService.GetFile(A<string>._)).Returns(fileNames);
        var fileService = new MockClass(mockedFileService);

        // Act
        var listOfFiles = fileService.GetFile(string.Empty);

        //Assert
        A.CallTo(() => mockedFileService.GetFile(string.Empty)).MustHaveHappenedOnceExactly();
        listOfFiles.Should().NotBeEmpty();
        listOfFiles.Should().BeEquivalentTo(fileNames);
    }

    [Fact]
    public void Read_Lines_From_File_Should_Return_String_Array()
    {
        // Arrange
        string[] randomLines = new[]
        {
            "line1",
            "line2",
            "line3",
        };

        A.CallTo(() => mockedFileService.ReadLinesFromFile(A<string>._)).Returns(randomLines);
        var mockedClass = new MockClass(mockedFileService);

        // Act
        var readLines = mockedClass.ReadLinesFromFile(string.Empty);

        // Assert
        A.CallTo(() => mockedFileService.ReadLinesFromFile(string.Empty)).MustHaveHappenedOnceExactly();
        readLines.Should().NotBeEmpty();
        readLines.Should().BeEquivalentTo(randomLines);
    }
}

public class MockClass : IFileService
{
    private readonly IFileService fileService;
    public MockClass(IFileService fileService) 
    {
        this.fileService = fileService;
    }
    public string[] GetFile(string fileName)
    {
        return fileService.GetFile(fileName);
    }

    public string[] ReadLinesFromFile(string file)
    {
        return fileService.ReadLinesFromFile(file);
    }
}
