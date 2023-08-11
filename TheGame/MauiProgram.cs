using Game.Services;
using Microsoft.Extensions.Logging;
using TheGame.ViewModels;
using TheGame.Views;
namespace TheGame
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<IFileService, FileService>();
            builder.Services.AddSingleton<IPlayerService, PlayerService>();

            builder.Services.AddTransient<LoginView>();
            builder.Services.AddTransient<LoginViewModel>();

            builder.Services.AddTransient<GameView>();
            builder.Services.AddTransient<GameViewModel>();

            builder.Services.AddTransient<SignupView>();
            builder.Services.AddTransient<SignupViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}