using System;
namespace MovieRecipeMobileAPp.MVVM.Models
{
	public class IngredientModel
	{
        public string Id { get; set; } 
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
    }

    //public enum Unit
    //{
    //    Gram,
    //    Kilogram,
    //    Ounce,
    //    Pound,
    //    Milliliter,
    //    Liter,
    //    Teaspoon,
    //    Tablespoon,
    //    Cup,
    //    Unit
    //}
}

