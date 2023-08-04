using Game.Services;
using System.ComponentModel;

namespace UnitTestProj
{
    public class FishServiceTest
    {
        private readonly string[] lines = { "Name", "Keeper Y / N", "Fish Y / N", "Points if kept", "Points if released" };

        [Fact]
        public void Test1()
        {
            // Arrange
            var mockedFileService = A.Fake<IFileService>();

            A.CallTo(() => mockedFileService.GetFile()).Returns(new string[] { "sample.csv" });
            A.CallTo<string[]>(() => mockedFileService.ReadLinesFromFile(A<string>.Ignored)).Returns(new[]
            {
                "Name,Color,Size",
                "Fish1,Red,Small",
                "Fish2,Blue,Medium",
                "Fish3,Yellow,Large"
            });
            var fishService = new FishService(mockedFileService);

            // Act
            List<Dictionary<string, string>> listOfFish = fishService.ReadFishFromCsv();

            // Assert
            _ = A.CallTo(() => mockedFileService.GetFile()).MustHaveHappenedOnceExactly();
            _ = A.CallTo(() => mockedFileService.ReadLinesFromFile(A<string>._)).MustHaveHappenedOnceExactly();
            listOfFish.Should().NotBeEmpty();

        }
    }
}