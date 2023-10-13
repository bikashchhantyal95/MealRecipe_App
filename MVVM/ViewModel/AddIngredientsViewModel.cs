using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieRecipeMobileAPp.MVVM.Models;

namespace MovieRecipeMobileAPp.MVVM.ViewModel
{
    internal partial class AddIngredientsViewModel : ObservableObject
    {
        private readonly string recipeKey;

        private readonly RecipeRepository recipeRepository;

        [ObservableProperty]
        public ObservableCollection<IngredientModel> ingredients = new();


        [ObservableProperty]
        private string ingredientName;

        [ObservableProperty]
        private int quantity;

        [ObservableProperty]
        private string unit;

        public AddIngredientsViewModel(string recipeKey)
		{
            this.recipeKey = recipeKey;
            recipeRepository = new RecipeRepository();
            LoadIngredients();
        }


        
        public void DeleteIngredient(IngredientModel ingredient)
        {
            Shell.Current.DisplayAlert("Hello", $"{ingredient.Name}", "OK");
        }


        private async Task SaveIngredientsToDatabaseAsync(object obj)
        {
            var ingredient = new IngredientModel
            {
                Name = IngredientName
            };
            bool result = await recipeRepository.AddIngredients(recipeKey, ingredient);
            if (result)
            {
                Console.WriteLine("Added Ingredient successfully.");
                IngredientName = String.Empty;
            }
            else
            {
                Console.WriteLine("Failed to add Ingredient successfully.");
            }

        }

        [RelayCommand]
        private async void AddIngredeint()
        {
            if (!string.IsNullOrWhiteSpace(IngredientName))
            {
                var ingredient = new IngredientModel
                {
                    Name = IngredientName,
                    Quantity = Quantity,
                    Unit = Unit

                };
                bool result = await recipeRepository.AddIngredients(recipeKey, ingredient);
                if (result)
                {
                    Console.WriteLine("Added Ingredeint successfully");
                }
                else
                {
                    Console.WriteLine("Failed to add Ingredeint successfully");
                }

                IngredientName = string.Empty;
            }


        }

        public async void LoadIngredients()
        {
            Ingredients.Clear();
            try
            {
                var allIngredeints = await recipeRepository.GetAllIngredientsOfRecipe(recipeKey);
                Ingredients.Clear();
                foreach (var ingredient in allIngredeints)
                {
                    Ingredients.Add(ingredient);
                }
                Console.WriteLine(Ingredients[0].Name);
            }
            catch(Exception e)
            {

            }
        }
    }
}

