using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Game.Services;

namespace TheGame.ViewModels
{
    public sealed partial class SignupViewModel : ObservableObject
    {
        private readonly IPlayerService playerService;
        [ObservableProperty]
        private string username = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;
        public SignupViewModel(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        [RelayCommand]
        private async Task CreateUser()
        {
            if (string.IsNullOrEmpty(Username))
            {
                await App.Current.MainPage.DisplayAlert("Invalid", "No username entered", "OK");
                this.Username = string.Empty;
                this.Password = string.Empty;
                return;
            }
            if (Password.Length >= 8)
            {
                playerService.InsertNewPlayer(Username, Password);
                this.Username = string.Empty;
                this.Password = string.Empty;
                await App.Current.MainPage.DisplayAlert("Successful", "User has been created!", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Invalid", "Password length needs to be at least 8 characters long", "OK");
                this.Password = string.Empty;
            }
            this.Username = string.Empty;
            this.Password = string.Empty;
        }
    }
}