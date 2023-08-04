using Game.Services;
namespace Game;

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
        builder.Services.AddSingleton<IFishService, FishService>();
        builder.Services.AddSingleton<IPlayerService, PlayerService>();

        return builder.Build();
	}
}
