using MovieRecipeMobileAPp.MVVM.View;

namespace MovieRecipeMobileAPp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CreateRecipePage), typeof(CreateRecipePage));
	}
}

