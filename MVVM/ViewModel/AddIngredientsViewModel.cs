using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieRecipeMobileAPp.MVVM.Models;
using static Java.Util.Jar.Attributes;

namespace MovieRecipeMobileAPp.MVVM.ViewModel
{
    internal partial class AddIngredientsViewModel : ObservableObject
    {
        private readonly string recipeKey;

        private readonly RecipeRepository recipeRepository;

        [ObservableProperty]
        public ObservableCollection<string> ingredients = new();


        [ObservableProperty]
        private string ingredientName;

        public AddIngredientsViewModel(string recipeKey)
		{
            this.recipeKey = recipeKey;
            recipeRepository = new RecipeRepository();
            _ = LoadIngredients();
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
                Ingredients.Add(IngredientName);


                var ingredient = new IngredientModel
                {
                    Name = IngredientName,
                    Quantity = 0,
                    Unit = "KG"

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

        public async Task LoadIngredients()
        {
            var allIngredeints = await recipeRepository.GetAllIngredients();
            Ingredients.Clear();
            foreach (var ingredient in allIngredeints)
            {
                Ingredients.Add(ingredient.Name);
            }
        }
    }
}

