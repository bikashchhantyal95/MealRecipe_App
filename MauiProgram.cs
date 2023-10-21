using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MovieRecipeMobileAPp.MVVM.View;

namespace MovieRecipeMobileAPp;

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
				fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcon");
				fonts.AddFont("Font-Awesome-6-Brands-Regular-400.otf", "FAB");
				fonts.AddFont("Font-Awesome-6-Free-Regular-400.otf", "FAR");
				fonts.AddFont("Font-Awesome-6-Free-Solid-900.otf", "FAS");
			})
			.UseMauiCommunityToolkit();
			;
		builder.Services.AddTransient<CreateRecipePage>();
		builder.Services.AddTransient<DashboardPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

