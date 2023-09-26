namespace MovieRecipeMobileAPp.MVVM.View;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();
	}

	private void AddRecipeButton_Tapped(Object sender, EventArgs e)
	{
		Navigation.PushAsync(new DashboardPage());
	}
}
