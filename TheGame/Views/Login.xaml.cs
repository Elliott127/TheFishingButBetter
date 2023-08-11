using TheGame.ViewModels;

namespace TheGame.Views;

public partial class LoginView : ContentPage
{
    public LoginView(LoginViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}