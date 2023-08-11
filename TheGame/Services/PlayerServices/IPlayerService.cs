using Game.Models;

namespace Game.Services;

/// <summary>
/// Defines the contract for managing player-related operations.
/// </summary>
public interface IPlayerService
{
    /// <summary>
    /// Retrieves a list of players' information.
    /// </summary>
    /// <returns>A list of dictionaries containing player information.</returns>
    public List<Dictionary<string, string>> GetListOfPlayers();

    /// <summary>
    /// Retrieves detailed information about a specific player.
    /// </summary>
    /// <param name="playerName">The name of the player to retrieve information for.</param>
    /// <returns>A Dictionary containing player information.</returns>
    public Dictionary<string, string> GetPlayerInfo(string playerName);


    /// <summary>
    /// Inserts a new player into the system.
    /// </summary>
    /// <param name="playerName">The name of the new player.</param>
    /// <param name="password">The password for the new player.</param>
    public void InsertNewPlayer(string playerName, string password);

    /// <summary>
    /// Adds a caught fish to the player's list of catches.
    /// </summary>
    /// <param name="fish">The name of the fish caught.</param>
    public void AddCatch(string fish);

    /// <summary>
    /// Retrieves the list of catches for the player.
    /// </summary>
    /// <returns>A list of caught fish.</returns>
    public List<string> GetCatches();

    public Task<bool> CheckUserCredentials(string username, string password);
}
