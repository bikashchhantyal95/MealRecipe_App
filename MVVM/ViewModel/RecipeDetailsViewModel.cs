using System;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieRecipeMobileAPp.MVVM.Models;
using Newtonsoft.Json;

namespace MovieRecipeMobileAPp.MVVM.ViewModel
{
	public partial class RecipeDetailsViewModel: ObservableObject
	{
        [ObservableProperty]
		public RecipeModel recipe;

		[ObservableProperty]
		private ObservableCollection<IngredientModel> ingredients;

        private readonly RecipeRepository recipeRepository;

        public RecipeDetailsViewModel(RecipeModel selctedRecipe)
		{
			recipe = selctedRecipe;
            Ingredients = new ObservableCollection<IngredientModel>();
            recipeRepository = new RecipeRepository();
		}

        [RelayCommand]
        public async Task LoadIngredients()
        {
            Ingredients.Clear();
            try
            {
                var allIngredeints = await recipeRepository.GetAllIngredientsOfRecipe(Recipe.Id);
                Ingredients.Clear();
                foreach (var ingredient in allIngredeints)
                {
                    Ingredients.Add(ingredient);
                }
                Console.WriteLine(Ingredients[0].Name);
            }
            catch (Exception e)
            {

            }
        }


        public static string FormatRecipeAsPlainText(RecipeModel recipe, ObservableCollection<IngredientModel> ingredients)
        {
            // Format the recipe and ingredients data as plain text
            StringBuilder plainTextBuilder = new StringBuilder();
            plainTextBuilder.AppendLine(recipe.Name);
            plainTextBuilder.AppendLine($"Courses: {recipe.Description}");
            //plainTextBuilder.AppendLine($"Serving size: {recipe.ServingSize}");
            plainTextBuilder.AppendLine($"Preparation time: {recipe.PrepTime} min");
            plainTextBuilder.AppendLine($"Cooking time: {recipe.CookingTime} min");

            plainTextBuilder.AppendLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                plainTextBuilder.AppendLine($"- {ingredient.Quantity} {ingredient.Unit} - {ingredient.Name}");
            }

            plainTextBuilder.AppendLine("Directions:");
            plainTextBuilder.AppendLine(recipe.Instructions);

           

            plainTextBuilder.AppendLine("Shared from my Recipe Book - the easy way to collect, organize, and share your recipes on your mobile, tablet, and PC.");

            return plainTextBuilder.ToString();
        }


        [RelayCommand]
        public async Task ShareRecipe()
        {
            // Generate plain text recipe
            string plainTextRecipe = FormatRecipeAsPlainText(Recipe, Ingredients);

            // Share the plain text using Xamarin.Essentials
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = plainTextRecipe,
                Title = "Share Recipe"
            });
        }

    }
}

