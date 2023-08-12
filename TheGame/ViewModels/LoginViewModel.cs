using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Game.Services;
using TheGame.Views;

namespace TheGame.ViewModels
{

    public partial class LoginViewModel : ObservableObject
    {
        private readonly IFileService fileService;
        private readonly IPlayerService playerService;

        [ObservableProperty]
        private string username = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        public LoginViewModel(IFileService fileService, IPlayerService playerService)
        {
            this.playerService = playerService;
            this.fileService = fileService;
        }

        [RelayCommand]
        public async Task Login()
        {
            await AttemptLogin();
        }

        public async Task AttemptLogin()
        {
            try
            {
                if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                {
                    Password = string.Empty;
                    await App.Current.MainPage.DisplayAlert("Invalid Input", "Not all fields are filled out", "OK");
                    return;
                }
                else if (playerService.CheckUserCredentials(Username, Password))
                {
                    playerService.SetActivePlayer(Username);
                    Username = string.Empty;
                    await Shell.Current.GoToAsync(nameof(GameView), true);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Invalid credentials", "The credentials you entered didn't match", "OK");
                }
                Password = string.Empty;
            }
            catch(Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Invalid credentials", "The credentials you entered didn't match", "OK");
                Password = string.Empty;
            }
        }

        [RelayCommand]
        private async Task Signup()
        {
            await Shell.Current.GoToAsync(nameof(SignupView), true);
        }
    }
}
