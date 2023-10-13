using MovieRecipeMobileAPp.MVVM.ViewModel;

namespace MovieRecipeMobileAPp.MVVM.View;

public partial class CreateIngredientPage : ContentPage
{
	private AddIngredientsViewModel _addIngredientsViewModel;
	public CreateIngredientPage(string recipeKey)
	{
		InitializeComponent();
	
		BindingContext = new AddIngredientsViewModel(recipeKey);
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		//_addIngredientsViewModel.LoadIngredients();
    }

    private void AddIngredientsBtn_Tapped(Object sender, EventArgs e)
    {
        Navigation.PushAsync(new IngredientsFormPage());
    }
}
