using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieRecipeMobileAPp.MVVM.Models;

namespace MovieRecipeMobileAPp.MVVM.ViewModel
{
	internal partial class IngredientsFormViewModel: ObservableObject
	{

        private readonly RecipeRepository recipeRepository;

        private string _recipekey;

		public IngredientsFormViewModel(string recipeKey)
		{
            _recipekey = recipeKey;
            recipeRepository = new RecipeRepository();
            CreateIngredients = new Command(CreateIngredientsBtnTapped);
        }

		[ObservableProperty]
		private string title;

		[ObservableProperty]
		private int quantity;

		[ObservableProperty]
		private string unit;

        public Command CreateIngredients { get; }


        public async void CreateIngredientsBtnTapped(Object sender)
        {
            await SaveIngredientsToDatabase();
        }

        private async Task  SaveIngredientsToDatabase()
        {
                var ingredient = new IngredientModel
                {
                    Name = Title,
                    Quantity = Quantity,
                    Unit = Unit
                };
                bool result = await recipeRepository.AddIngredients(recipeId: _recipekey, ingredient: ingredient);
                if (result)
                {
                    await Shell.Current.DisplayAlert("Ingrediennt", $"{ingredient.Name} added successfully.", "OK");
                }
                else
                {
                    Console.WriteLine("Failed to add Recipe successfully.");
                }   
        }
    }
}

