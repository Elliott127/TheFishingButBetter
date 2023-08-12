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


        public EndGameViewModel(IPlayerService playerService)
        {
            this.playerService = playerService;
            playerName = playerService.GetActivePlayer();
        }
    }
}
