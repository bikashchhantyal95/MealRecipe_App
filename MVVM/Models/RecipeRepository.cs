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

        public async Task<bool> AddRecipe(RecipeModel recipe)
        {
            try
            {
                var res = await firebaseClient.Child("Recipe").PostAsync(recipe);
                Console.WriteLine("Recipe added successfully.");
                return true;

            }
            catch(Exception e)
            {
                Console.WriteLine("Error adding recipe");
                return false;
            }
        }

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
                
            }catch(Exception e)
            {
                return new List<RecipeModel>();
            }
        }
    }

    public static class FirebaseConfig
    {
        public const string firebaseDatabaseUrl = "https://recipebook-5d5d2-default-rtdb.firebaseio.com/";
    }
}

