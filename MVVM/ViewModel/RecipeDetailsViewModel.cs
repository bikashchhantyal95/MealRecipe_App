using System;
using CommunityToolkit.Mvvm.ComponentModel;
using MovieRecipeMobileAPp.MVVM.Models;

namespace MovieRecipeMobileAPp.MVVM.ViewModel
{
	public partial class RecipeDetailsViewModel: ObservableObject
	{
        [ObservableProperty]
		public RecipeModel recipe;

		public RecipeDetailsViewModel(RecipeModel selctedRecipe)
		{
			recipe = selctedRecipe;
		}
	}
}

