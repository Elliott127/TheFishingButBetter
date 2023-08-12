using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Game.Services;
using Game.ViewModels.Base;
using TheGame.Views;

namespace TheGame.ViewModels;

public partial class GameViewModel : ViewModelBase
{
    private readonly IFileService fileService;
    private readonly IPlayerService playerService;
    private readonly List<Dictionary<string, string>> fishList;
    private static int playersScore;

    [ObservableProperty]
    private string resultLabel = string.Empty;

    [ObservableProperty]
    private string score = playersScore.ToString();

    public GameViewModel(IFileService fileService, IPlayerService playerService)
    {
        this.fileService = fileService;
        this.playerService = playerService;
        fishList = fileService.ReadFromCsv("Fishing.csv");
        playersScore = 0;
    }

    public override async Task InitialiseAsync(object navigationData)
    {

    }

    [RelayCommand]
    public async Task OnCastLineClicked()
    {
        Random random = new();
        int result = random.Next(1, 6);
        var fishCaughtStats = fishList[result];
        var fishCaughtName = fishCaughtStats["Name"];
        ResultLabel = fishCaughtName;
        bool answer = await App.Current.MainPage.DisplayAlert($"You Caught a {fishCaughtName}", "Would you like to keep it?", "Yes", "No");
        string pointsToRetrieve = answer ? fishCaughtStats["Points if kept"] : fishCaughtStats["Points if released"];
        if (fishCaughtStats["Fish Y/N"] == "Y")
        {
            playerService.AddCatch(fishCaughtName);
        }

        playersScore += Convert.ToInt32(pointsToRetrieve);
        Score = playersScore.ToString();
    }

[RelayCommand]
    public async Task EndGame()
    {
        await Shell.Current.GoToAsync(nameof(LoginView), true);
    }
}
