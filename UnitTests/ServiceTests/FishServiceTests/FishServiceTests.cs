using Game.Services;
using System.ComponentModel;

namespace UnitTests.Services;

public class FishServiceTest
{
    [Fact]
    public void Should_Have_Successfully_Read_Fish_From_CSV()
    {
        string[] csv = new[]{
            "Name,Color,Size",
            "Fish1,Red,Small",
            "Fish2,Blue,Medium",
            "Fish3,Yellow,Large"
        };
        // Arrange
        var mockedFileService = A.Fake<IFileService>();

        A.CallTo(() => mockedFileService.GetFile(A<string>._)).Returns(new string[] { "sample.csv" });
        A.CallTo<string[]>(() => mockedFileService.ReadLinesFromFile(A<string>.Ignored)).Returns(csv);
        var fishService = new FishService(mockedFileService);

        // Act
        List<Dictionary<string, string>> listOfFish = fishService.ReadFishFromCsv();

        // Assert
        _ = A.CallTo(() => mockedFileService.GetFile(A<string>._)).MustHaveHappenedOnceExactly();
        _ = A.CallTo(() => mockedFileService.ReadLinesFromFile(A<string>._)).MustHaveHappenedOnceExactly();
        listOfFish.Should().NotBeEmpty();
        listOfFish.Should().BeEquivalentTo(listOfFish);
    }
}