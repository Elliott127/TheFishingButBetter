using Game.Models;

namespace Game.Services;

interface IPlayerService
{
    public List<string> GetPlayers();
    public Dictionary<dynamic, Player> GetPlayerInfo();

}
