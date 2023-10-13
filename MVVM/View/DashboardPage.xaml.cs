using MovieRecipeMobileAPp.MVVM.ViewModel;

namespace MovieRecipeMobileAPp.MVVM.View;

public partial class DashboardPage : ContentPage
{
	private RecipeViewModel _recipeViewModel;
	public DashboardPage()
	{
		InitializeComponent();
		_recipeViewModel = new RecipeViewModel();
		BindingContext = _recipeViewModel;
	}

	private void AddRecipeButton_Tapped(Object sender, EventArgs e)
	{
		Navigation.PushAsync(new CreateRecipePage());
	}

    private void AddIngredientsBtn_Tapped(Object sender, EventArgs e)
    {
        //Navigation.PushAsync(new CreateIngredientPage());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        //Load all recipes
        _recipeViewModel.LoadAllRecipes();

    }

}
