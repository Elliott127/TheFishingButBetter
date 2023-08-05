using Game.Models;
namespace Game.Services;

class PlayerService : IPlayerService
{
    private readonly IFileService fileService;
    public PlayerService(IFileService fileService)
    {
        this.fileService = fileService;
    }
    public Dictionary<dynamic, Player> GetPlayerInfo()
    {

        throw new NotImplementedException();
    }

    public List<string> GetPlayers()
    {
        throw new NotImplementedException();
    }
}
