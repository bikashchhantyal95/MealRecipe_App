using MovieRecipeMobileAPp.MVVM.ViewModel;

namespace MovieRecipeMobileAPp.MVVM.View;

public partial class CreateIngredientPage : ContentPage
{
	public CreateIngredientPage(string recipeKey)
	{
		InitializeComponent();

		BindingContext = new AddIngredientsViewModel(recipeKey);
	}
}
