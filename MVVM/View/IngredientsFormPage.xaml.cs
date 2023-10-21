using MovieRecipeMobileAPp.MVVM.ViewModel;

namespace MovieRecipeMobileAPp.MVVM.View;

public partial class IngredientsFormPage : ContentPage
{
	private readonly IngredientsFormViewModel _viewModel;
	public IngredientsFormPage(string recipeKey)
	{
		InitializeComponent();
		_viewModel = new IngredientsFormViewModel(recipeKey);
		BindingContext = _viewModel;
	}

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
    }
}
