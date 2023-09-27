using MovieRecipeMobileAPp.MVVM.ViewModel;

namespace MovieRecipeMobileAPp.MVVM.View;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();
		BindingContext = new RecipeViewModel();
	}

	private void AddRecipeButton_Tapped(Object sender, EventArgs e)
	{
		Navigation.PushAsync(new CreateRecipePage());
	}

}
