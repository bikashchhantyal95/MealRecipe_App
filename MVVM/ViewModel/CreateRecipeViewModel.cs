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

            //ButtonText = string.IsNullOrEmpty(Recipe.Id) ? "Create Recipe" : "Update Recipe";
        }

        [ObservableProperty]
        private string errorName;

        [ObservableProperty]
        private string errorDescription;

        [ObservableProperty]
        private string errorCookingTime;

        [ObservableProperty]
        private string errorPrepTime;

        [ObservableProperty]
        private string buttonText;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private RecipeModel _recipe = new RecipeModel();

        public Command CreateRecipe { get; }


        private async void CreateRecipeBtnTapped()
        {
            if (ValidateRecipe())
            {
                await SaveRecipeToDatabaseAsync();
            }
            
        }

        private async Task SaveRecipeToDatabaseAsync()
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
                    await Shell.Current.DisplayAlert("Sucessfull", $"'{recipe.Name}' created successfully", "Ok");
                    Recipe.Name = String.Empty;
                    Recipe.Description = String.Empty;
                    await Shell.Current.Navigation.PopAsync();

                }
                else
                {
                    await Shell.Current.DisplayAlert("Error!!!", $"'{recipe.Name}' failed to save.!!!", "Ok");
                    Console.WriteLine("Failed to add Recipe !!!!!.");
                }


               
            }
            else {
               

                await recipeRepository.UpdateRecipeById(Recipe);
                await Shell.Current.DisplayAlert("Updated Success!!!", $"'{Recipe.Name}' updated successfully", "Ok");
            }

            

        }


        private bool ValidateRecipe()
        {
            ErrorName = string.IsNullOrWhiteSpace(Recipe.Name) ? "Please enter a recipe name." : string.Empty;
            ErrorCookingTime = Recipe.CookingTime <= 0 ? "Cooking time must be greater than zero." : string.Empty;
            ErrorPrepTime = Recipe.PrepTime <= 0 ? "Preparation time must be greater than zero." : string.Empty;
            ErrorDescription = string.IsNullOrWhiteSpace(Recipe.Description) ? "Please enter a recipe description." : string.Empty;

            return string.IsNullOrEmpty(ErrorName) && string.IsNullOrEmpty(ErrorCookingTime) && string.IsNullOrEmpty(ErrorDescription) && string.IsNullOrEmpty(ErrorPrepTime);
        }

    }
}