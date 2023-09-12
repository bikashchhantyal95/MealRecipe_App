using System;
namespace MovieRecipeMobileAPp.MVVM.Models
{
	public class RecipeModel
	{
        public int Id { get; set; } // Unique identifier for the recipe
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
    }
}

