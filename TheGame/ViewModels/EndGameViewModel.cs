using Game.ViewModels.Base;
using Game.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TheGame.ViewModels
{
    public partial class EndGameViewModel : ViewModelBase
    {
        private readonly IPlayerService playerService;

        [ObservableProperty]
        private string playerName;

        [ObservableProperty]
        private string score;

        private List<string> catches;

        [ObservableProperty]
        private Dictionary<string, int> catchCount;

        public EndGameViewModel(IPlayerService playerService)
        {
            this.playerService = playerService;
            playerName = $" {playerService.GetActivePlayer()}!";
            score = $" {playerService.GetPlayerScore()}!";
            catches = playerService.GetCatches();
            CountCatches();
        }

        private void CountCatches()
        {
            CatchCount = new();
            foreach (var fish in catches)
            {
                if (CatchCount.ContainsKey(fish))
                {
                    CatchCount[fish]++;
                }
                else
                {
                    CatchCount.Add(fish, 1);
                }
            }
        }       
    }
}
