using TheGame.ViewModels;

namespace TheGame.Views;

public partial class GameView : ContentPage
{
	public GameView(GameViewModel viewModel)
	{
        this.BindingContext = viewModel;
		InitializeComponent();
	}
}