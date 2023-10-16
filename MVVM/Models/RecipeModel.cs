using System;
using CommunityToolkit.Mvvm.Input;

namespace MovieRecipeMobileAPp.MVVM.Models
{
	public partial class RecipeModel
	{
        public string Id { get; set; } // Unique identifier for the recipe

        public string Name { get; set; } //Name of the recipe

        public string Description { get; set; }// Description of Recipe

        public int CookingTime { get; set; } // Cooking time for recipe

        public int PrepTime { get; set; } //Cooking preparation time

        public DateTime Created { get; set; } //Time whwn recupe was created

        public string Author { get; set; } // Author of the recipe

        public string Image { get; set; } // Recipe Image
    }
}

