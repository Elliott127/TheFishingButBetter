using TheGame.ViewModels;

namespace TheGame.Views;

public partial class SignupView : ContentPage
{
    public SignupView(SignupViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}