using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Database;
using Firebase.Database.Query;
using MovieRecipeMobileAPp.MVVM.Models;

namespace MovieRecipeMobileAPp.MVVM.ViewModel
{
    [QueryProperty(nameof(Recipe), "Recipe")]
    internal partial class CreateRecipeViewModel : ObservableObject
    {
        private readonly RecipeRepository recipeRepository;

        public CreateRecipeViewModel()
        {
            recipeRepository = new RecipeRepository();
            CreateRecipe = new Command(CreateRecipeBtnTapped);

            ButtonText = string.IsNullOrEmpty(Recipe.Id) ? "Create Recipe" : "Update Recipe";
        }

        //[ObservableProperty]
        //private string name;

        //[ObservableProperty]
        //private string description;

        //[ObservableProperty]
        //private int cookingTime;

        [ObservableProperty]
        private string buttonText;

        [ObservableProperty]
        private RecipeModel _recipe = new RecipeModel();

        public Command CreateRecipe { get; }


        private async void CreateRecipeBtnTapped(object obj)
        {
            await SaveRecipeToDatabaseAsync(obj);
        }

        private async Task SaveRecipeToDatabaseAsync(object obj)
        {
            if (string.IsNullOrEmpty(Recipe.Id))
            {
                
                var recipe = new RecipeModel
                {
                    Name = Recipe.Name,
                    Description = Recipe.Description,
                    CookingTime = Recipe.CookingTime
                };



                bool result = await recipeRepository.AddRecipe(recipe);
                if (result)
                {
                    await Shell.Current.DisplayAlert("Sucessfull", $"'{recipe.Name}' created successfully", "Ok", null);
                    Recipe.Name = String.Empty;
                    Recipe.Description = String.Empty;
                }
                else
                {
                    Console.WriteLine("Failed to add Recipe !!!!!.");
                }


               
            }
            else {
               

                await recipeRepository.UpdateRecipeById(Recipe);
                await Shell.Current.DisplayAlert("Updated Success!!!", $"'{Recipe.Name}' updated successfully", "Ok", null);
            }

            

        }


    }
}