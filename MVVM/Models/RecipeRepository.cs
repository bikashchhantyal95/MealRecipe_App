using System;
using System.Collections.ObjectModel;
using Firebase.Database;
using Firebase.Database.Query;

namespace MovieRecipeMobileAPp.MVVM.Models
{
    public class RecipeRepository
    {
        private readonly FirebaseClient firebaseClient;
        //private List<RecipeModel> recipes;

        public RecipeRepository()
        {
            //recipes = new List<RecipeModel>
            //{
            //    new RecipeModel{ Id = "1", Name= "Recipe 1", Description = "Description 1", Instructions = "Instructions 1"},
            //    new RecipeModel{ Id = "2", Name= "Recipe 2", Description = "Description 2", Instructions = "Instructions 2"},
            //    new RecipeModel{ Id = "3", Name= "Recipe 3", Description = "Description 3", Instructions = "Instructions 3"}
            //};

            firebaseClient = new FirebaseClient(FirebaseConfig.firebaseDatabaseUrl);
        }

        //Add a new recipe to the firebase database
        public async Task<bool> AddRecipe(RecipeModel recipe)
        {
            try
            {
                var res = await firebaseClient.Child("Recipe").PostAsync(recipe);
                recipe.Id = res.Key;
                Console.WriteLine("Recipe added successfully.");
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding recipe");
                return false;
            }
        }

        //Retrieve all recipes from the firebase database
        public async Task<List<RecipeModel>> GetAllRecipes()
        {
            try
            {
                var recipes = await firebaseClient.Child("Recipe").OnceAsync<RecipeModel>();

                return (
                    recipes.Select(
                    item => new RecipeModel
                    {
                        Id = item.Key,
                        Name = item.Object.Name,
                        Description = item.Object.Description,
                        Instructions = item.Object.Instructions
                    }).ToList()
                    );

            }
            catch (Exception e)
            {
                return new List<RecipeModel>();
            }
        }
    
    // Remove recipe from the firebase database using key
    public async Task<bool> RemoveRecipe(string recipeKey)
    {
        try
        {
             await firebaseClient.Child("Recipe").Child(recipeKey).DeleteAsync();
                return true;

        }catch(Exception e)
        {
                Console.WriteLine($"Error deleting recipe: {e.Message}");
                return false;
        }
    }

        //Fetch recipe detail using key
    public async Task<RecipeModel> GetRecipeDetail(string recipeKey)
     {
            try
            {
                var recipe = await firebaseClient.Child("Recipe").Child(recipeKey).OnceSingleAsync<RecipeModel>();

                return recipe;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching recipe detail: {e.Message}");
                return null;
            }
       }

        public async Task<bool> UpdateRecipe(RecipeModel recipe)
        {
            try
            {
                await firebaseClient.Child("Recipes").Child(recipe.Id).PutAsync(recipe);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error updating recupe: {e.Message}");
                return false;
            }
    }
    }


    

    //Firebase configuration class
    public static class FirebaseConfig
    {
        public const string firebaseDatabaseUrl = "https://recipebook-5d5d2-default-rtdb.firebaseio.com/";
    }

}
