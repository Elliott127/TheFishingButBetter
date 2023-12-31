﻿using TheGame.Views;
namespace TheGame
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(SignupView), typeof(SignupView));
            Routing.RegisterRoute(nameof(GameView), typeof(GameView));
            Routing.RegisterRoute(nameof(EndGameView), typeof(EndGameView));
        }
    }
}