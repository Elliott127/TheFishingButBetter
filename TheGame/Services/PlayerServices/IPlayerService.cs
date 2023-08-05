using Game.Models;

namespace Game.Services;

interface IPlayerService
{
    public List<string> GetListOfPlayers();
    public Dictionary<dynamic, Player> GetPlayerInfo();

}
