using MovieRecipeMobileAPp.MVVM.ViewModel;

namespace MovieRecipeMobileAPp.MVVM.View;

public partial class RecipeDetailPage : ContentPage
{
	
	public RecipeDetailPage(RecipeDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    void AddIngredients_Button_Clicked(Object sender, EventArgs e)
    {
		if (BindingContext is RecipeDetailsViewModel vm)
		{
			string recipeKey = vm.Recipe.Id;
			Navigation.PushAsync(new CreateIngredientPage(recipeKey));
		}


		//Navigation.PushAsync(new CreateIngredientPage());
    }


}
