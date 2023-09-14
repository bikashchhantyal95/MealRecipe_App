using MovieRecipeMobileAPp.MVVM.View;

namespace MovieRecipeMobileAPp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new Dashboard();
	}
}

