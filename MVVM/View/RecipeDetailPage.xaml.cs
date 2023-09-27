namespace MovieRecipeMobileAPp.MVVM.View;

public partial class RecipeDetailPage : ContentPage
{
	public RecipeDetailPage()
	{
		InitializeComponent();
	}

    void AddIngredients_Button_Clicked(Object sender, EventArgs e)
    {
		Navigation.PushAsync(new CreateIngredientPage());
    }
}
