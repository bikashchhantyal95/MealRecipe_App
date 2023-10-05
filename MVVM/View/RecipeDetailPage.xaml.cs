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
		Navigation.PushAsync(new CreateIngredientPage());
    }
}
