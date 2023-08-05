using Game.Services;

namespace UnitTests.Services;

public class PlayerServiceTests
{
    private readonly IFileService fileService;
    private readonly IPlayerService playerService;
    private readonly Dictionary<string, string> fakePlayer = new()
        {
            {"id","1" },
            {"player name","Test" },
            {"password", "password" },
            {"score", "0" }
        };
    private readonly List<Dictionary<string, string>> fakePlayers;

    public PlayerServiceTests()
    {
        fileService = A.Fake<IFileService>();
        playerService = new PlayerService(fileService);
        fakePlayers = new()
        {
            fakePlayer
        };
    }

    [Fact]
    public void Get_List_Of_Players_Should_Retrieve_List_Of_Players()
    {
        // Arrange
        A.CallTo(() => fileService.ReadFromCsv(A<string>._)).Returns(fakePlayers);

        // Act
        var players = playerService.GetListOfPlayers();

        // Assert
        A.CallTo(() => fileService.ReadFromCsv(A<string>._)).MustHaveHappenedOnceExactly();
        players.Should().NotBeNullOrEmpty();
        players.Should().Contain(fakePlayer);
    }

    [Fact]
    public void Get_Player_Info_Should_Retrieve_Single_User()
    {
        // Arrange
        A.CallTo(() => fileService.ReadFromCsv(A<string>._)).Returns(fakePlayers);

        // Act
        var player = playerService.GetPlayerInfo("Test");
        // Assert
        A.CallTo(() => fileService.ReadFromCsv(A<string>._)).MustHaveHappenedOnceExactly();
        player.Should().NotBeNullOrEmpty();
        player.Should().ContainValue("Test");
        player.Should().ContainValue("0");
    }
}
