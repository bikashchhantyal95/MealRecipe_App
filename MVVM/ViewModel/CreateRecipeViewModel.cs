using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Database;
using Firebase.Database.Query;
using MovieRecipeMobileAPp.MVVM.Models;

namespace MovieRecipeMobileAPp.MVVM.ViewModel
{
    internal partial class CreateRecipeViewModel : ObservableObject
    {
        private readonly RecipeRepository recipeRepository;

        public CreateRecipeViewModel()
        {
            recipeRepository = new RecipeRepository();
            CreateRecipe = new Command(CreateRecipeBtnTapped);
        }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private int cookingTime;

        public Command CreateRecipe { get; }


        private async void CreateRecipeBtnTapped(object obj)
        {
            await SaveRecipeToDatabaseAsync(obj);
        }

        private async Task SaveRecipeToDatabaseAsync(object obj)
        {
            var recipe = new RecipeModel
            {
                Name = Name,
                Description = Description,
                CookingTime = CookingTime
            };
            bool result = await recipeRepository.AddRecipe(recipe);
            if (result)
            {
                Console.WriteLine("Added Recipe successfully.");
                Name = String.Empty;
                Description = String.Empty;
            }
            else
            {
                Console.WriteLine("Failed to add Recipe successfully.");
            }

        }


    }
}