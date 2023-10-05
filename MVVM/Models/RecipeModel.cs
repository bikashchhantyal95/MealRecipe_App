using System;
namespace MovieRecipeMobileAPp.MVVM.Models
{
	public class RecipeModel
	{
        public string Id { get; set; } // Unique identifier for the recipe

        public string Name { get; set; } //Name of the recipe

        public string Description { get; set; }// Description of Recipe

        public string Instructions { get; set; }//Instructions for Cooking the recipe

        public int CookingTime { get; set; } // Cooking time for recipe
    }
}

