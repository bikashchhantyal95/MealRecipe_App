using System;
namespace MovieRecipeMobileAPp.MVVM.Models
{
	public class RecipeRepository
	{
        private List<RecipeModel> recipes;

        public RecipeRepository()
        {
            recipes = new List<RecipeModel>
            {
                new RecipeModel{ Id = 1, Name= "Recipe 1", Description = "Description 1", Instructions = "Instructions 1"},
                new RecipeModel{ Id = 2, Name= "Recipe 2", Description = "Description 2", Instructions = "Instructions 2"},
                new RecipeModel{ Id = 3, Name= "Recipe 3", Description = "Description 3", Instructions = "Instructions 3"}
            };
        }

        public List<RecipeModel> GetAllRecipes()
        {
            return recipes;
        }
    }
}

