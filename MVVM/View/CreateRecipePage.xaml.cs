using MovieRecipeMobileAPp.MVVM.ViewModel;

namespace MovieRecipeMobileAPp.MVVM.View;

public partial class CreateRecipePage : ContentPage
{
	public CreateRecipePage()
	{
		InitializeComponent();
		BindingContext = new CreateRecipeViewModel();
	}
}
