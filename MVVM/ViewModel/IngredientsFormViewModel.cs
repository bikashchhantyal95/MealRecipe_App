using System;
using CommunityToolkit.Mvvm.ComponentModel;
using MovieRecipeMobileAPp.MVVM.Models;
using static Java.Util.Jar.Attributes;

namespace MovieRecipeMobileAPp.MVVM.ViewModel
{
	internal partial class IngredientsFormViewModel: ObservableObject
	{

        private readonly RecipeRepository recipeRepository;
		public IngredientsFormViewModel()
		{
		}

		[ObservableProperty]
		private string title;

		[ObservableProperty]
		private int quantity;

		[ObservableProperty]
		private string unit;

        private async Task SaveIngredientsToDatabaseAsync(object obj)
        {
            var recipe = new IngredientModel
            {
                Name = Title,
                Quantity = Quantity,
                Unit = Unit
            };
            //bool result = await recipeRepository.AddIngredients()
            //if (result)
            //{
            //    Console.WriteLine("Added Recipe successfully.");
            //}
            //else
            //{
            //    Console.WriteLine("Failed to add Recipe successfully.");
            //}

        }
    }
}

