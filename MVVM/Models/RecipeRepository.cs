using System;
using System.Collections.ObjectModel;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Maui.Storage;

namespace MovieRecipeMobileAPp.MVVM.Models
{
    public class RecipeRepository
    {
        private readonly FirebaseClient firebaseClient;

        public RecipeRepository()
        {
            firebaseClient = new FirebaseClient(FirebaseConfig.firebaseDatabaseUrl);
        }

        //Add a new recipe to the firebase database
        public async Task<bool> AddRecipe(RecipeModel recipe)
        {
            try
            {
                // recipe details before adding
                Console.WriteLine($"Adding recipe: Name={recipe.Name}, Desc={recipe.Description}");
                var res = await firebaseClient.Child("Recipe").PostAsync(recipe);
                //return recipeKey.Key;
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
                    }).ToList()
                    );

            }
            catch (Exception e)
            {
                return new List<RecipeModel>();
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

        public async Task<bool> UpdateRecipeById(RecipeModel recipe)
        {
            try
            {
                await firebaseClient.Child("Recipe").Child(recipe.Id).PutAsync(recipe);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        // Remove recipe from the firebase database using key
        public async Task<bool> RemoveRecipe(RecipeModel recipe)
        {
            try
            {
                await firebaseClient.Child("Recipe").Child(recipe.Id).DeleteAsync();

                //if (recipeToDelete != null)
                //    {
                //        await firebaseClient.Child("Recipe").Child(recipeToDelete.Key).DeleteAsync();
                //    }
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error deleting recipe: {e.Message}");
                Console.WriteLine($"Error deleting recipe: {recipe.Id}");
                return false;
            }
        }

        public async Task<bool> AddIngredients(string recipeId, IngredientModel ingredient)
        {
            try
            {
                var ingredientId = Guid.NewGuid().ToString();
                await firebaseClient.Child("Ingredients").Child(recipeId).Child(ingredientId).PutAsync(ingredient);
                //ingredient.Id = res.Key;
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error adding ingredients: {e.Message}");
                return false;
            }
        }


        //Retrieve all recipes from the firebase database
        public async Task<List<IngredientModel>> GetAllIngredientsOfRecipe(string recipeKey)
        {
            try
            {
                var ingredients = await firebaseClient.Child("Ingredients").Child(recipeKey).OnceAsync<IngredientModel>();
                return (
                    ingredients.Select(
                    item => new IngredientModel
                    {
                        Id = item.Key,
                        Name = item.Object.Name,
                        Quantity = item.Object.Quantity,
                        Unit = item.Object.Unit
                    }).ToList()
                    );

            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to fetch ingredients :{e.Message}");
                return new List<IngredientModel>();
            }
        }

      

        public async Task<bool> RemoveIngredient(string recipeKey, string ingredientKey)
        {
            try
            {
                await firebaseClient.Child("Ingredients").Child(recipeKey).Child(ingredientKey).DeleteAsync();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error deleting recipe: {e.Message}");
                
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
