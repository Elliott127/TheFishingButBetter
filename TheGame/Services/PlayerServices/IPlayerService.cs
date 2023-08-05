using Game.Models;

namespace Game.Services;

interface IPlayerService
{
    public List<Dictionary<string, string>> GetListOfPlayers();
    public string[] GetPlayerInfo(string playerName);
    public void InsertNewPlayer(string playerName, string password);
    public void AddCatch(string fish);
    public List<string> GetCatches();
}
