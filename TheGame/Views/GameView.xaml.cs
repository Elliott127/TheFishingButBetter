namespace TheGame.Views;

public partial class GameView : ContentPage
{
	public GameView()
	{
		InitializeComponent();
	}
	private void OnCastLineClicked(object sender, EventArgs e)
{
    Random random = new();
    int result = random.Next(1, 7);

    if (result == 1)
    {
        ResultLabel.Text = "You caught a small fish!";
    }
    else if (result == 2)
    {
        ResultLabel.Text = "You caught a medium fish!";
    }
    else if (result == 3)
    {
        ResultLabel.Text = "You caught a large fish!";
    }
    else if (result == 4)
    {
        ResultLabel.Text = "You caught a boot...";
    }
    else if (result == 5)
    {
        ResultLabel.Text = "You caught a tin can...";
    }
    else
    {
        ResultLabel.Text = "You caught nothing...";
    }
}
}