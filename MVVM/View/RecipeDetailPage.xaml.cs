using MovieRecipeMobileAPp.MVVM.ViewModel;

namespace MovieRecipeMobileAPp.MVVM.View;

public partial class RecipeDetailPage : ContentPage
{
	private readonly RecipeDetailsViewModel _recipeDetailsViewModel;	
	public RecipeDetailPage(RecipeDetailsViewModel vm)
	{
		InitializeComponent();
		_recipeDetailsViewModel = vm;
		BindingContext = _recipeDetailsViewModel;
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

    protected override void OnAppearing()
    {
        base.OnAppearing();
		_recipeDetailsViewModel.LoadIngredientsCommand.Execute(null);
    }

}
