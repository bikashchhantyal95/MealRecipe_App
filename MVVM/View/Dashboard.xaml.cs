using MovieRecipeMobileAPp.MVVM.ViewModel;

namespace MovieRecipeMobileAPp.MVVM.View;

public partial class Dashboard : ContentPage
{
	public Dashboard()
	{
		InitializeComponent();
		BindingContext = new RecipeViewModel();
	}
}
