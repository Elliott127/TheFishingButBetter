using TheGame.ViewModels;

namespace TheGame.Views;

public partial class EndGameView : ContentPage
{
	public EndGameView(EndGameViewModel viewModel)
	{
		this.BindingContext = viewModel;
		InitializeComponent();
	}
}