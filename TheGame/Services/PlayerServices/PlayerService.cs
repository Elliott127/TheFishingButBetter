using Game.Models;
using System.Security.Cryptography;
using System.Text;

namespace Game.Services;

/// <summary>
/// Represents a service responsible for managing player-related operations.
/// </summary>
public class PlayerService : IPlayerService
{
    private readonly IFileService fileService;
    private readonly List<string> listOfCatches = new();
    private static string playerName = string.Empty;
    /// <summary>
    /// Initializes a new instance of the <see cref="PlayerService"/> class.
    /// </summary>
    /// <param name="fileService">An implementation of the file service for reading/writing data.</param>

    public PlayerService(IFileService fileService)
    {
        this.fileService = fileService;
    }

    /// <inheritdoc/>
    public Dictionary<string, string> GetPlayerInfo(string playerName)
    {
        List<Dictionary<string, string>> players = GetListOfPlayers();
        players = players.Where(x => x.ContainsValue(playerName)).ToList();
        Dictionary<string, string> player = players.First();

        return player;
    }

    /// <inheritdoc/>
    public List<Dictionary<string, string>> GetListOfPlayers()
    {
        List<Dictionary<string, string>> players = fileService.ReadFromCsv("PlayerInfo.csv");
        return FilterPlayerInformation(players);
    }

    /// <inheritdoc/>
    public void InsertNewPlayer(string playerName, string password)
    {
        playerName = playerName.Trim().ToLower();
        string id = GetListOfPlayers().Count == 1 ? "1" : (GetListOfPlayers().Count + 1).ToString();
        string hashedPassword = GetMD5Hash(password);
        string content = $"{id},{playerName},{hashedPassword},0";

        fileService.WriteToFile("PlayerInfo.csv", content);
    }

    /// <inheritdoc/>
    public void AddCatch(string fish)
    {
        listOfCatches.Add(fish);
    }

    /// <inheritdoc/>
    public List<string> GetCatches()
    {
        return listOfCatches;
    }

    /// <summary>
    /// Private method to filter player information by removing sensitive data.
    /// </summary>
    /// <param name="listOfPlayers">the list of players to be filtered</param>
    /// <returns></returns>
    private static List<Dictionary<string, string>> FilterPlayerInformation(List<Dictionary<string, string>> listOfPlayers)
    {
        foreach (var player in listOfPlayers)
        {
            player.Remove("password");
        }
        return listOfPlayers;
    }

    private static string GetMD5Hash(string value)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(value);
        byte[] hashBytes = MD5.HashData(inputBytes);

        StringBuilder sb = new();

        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("x2")); // Convert byte to hexadecimal string
        }

        return sb.ToString();
    }

    public bool CheckUserCredentials(string username, string password)
    {
        username = username.Trim().ToLower();
        List<Dictionary<string, string>> players = fileService.ReadFromCsv("PlayerInfo.csv");
        password = GetMD5Hash(password);
        var player = players.Where(x => x.Any(player => player.Value.ToLower() == username)).FirstOrDefault();
        var credentialsMatch = player.Any(player => player.Value == password);
        return credentialsMatch;
    }

    public void SetActivePlayer(string username)
    {
        char firstLetter = username[0];
        playerName = firstLetter + username.Substring(1, username.Length);
    }

    public string GetActivePlayer()
    {
        return playerName;
    }
}
