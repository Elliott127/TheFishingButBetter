namespace Game.Services;

class PlayerService : IPlayerService
{
    private readonly IFileService fileService;
    private readonly List<string> listOfCatches = new();

    public PlayerService(IFileService fileService)
    {
        this.fileService = fileService;
    }

    public string[] GetPlayerInfo(string playerName)
    {
        throw new NotImplementedException();
    }

    public List<Dictionary<string, string>> GetListOfPlayers()
    {
        List<Dictionary<string, string>> players = fileService.ReadFromCsv("PlayerInfo.csv");
        return FilterPlayerInformation(players);
    }

    public void AddCatch(string fish)
    {
        listOfCatches.Add(fish);
    }

    public List<string> GetCatches()
    {
        return listOfCatches;
    }

    public void InsertNewPlayer(string playerName, string password)
    {
        throw new NotImplementedException();
    }

    private static List<Dictionary<string, string>> FilterPlayerInformation(List<Dictionary<string, string>> listOfPlayers)
    {
        foreach (var player in listOfPlayers)
        {
            player.Remove("password");
        }
        return listOfPlayers;
    }

}
