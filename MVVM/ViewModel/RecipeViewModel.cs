using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MovieRecipeMobileAPp.MVVM.Models;

namespace MovieRecipeMobileAPp.MVVM.ViewModel
{
    internal partial class RecipeViewModel : ObservableObject
	{
		//public event PropertyChangedEventHandler PropertyChanged;

        private readonly RecipeRepository recipeRepository;

		[ObservableProperty]
		public ObservableCollection<RecipeModel> recipes = new();

        //private List<RecipeModel> recipes;

		//public List<RecipeModel> Recipes
		//{
		//	get { return recipes; }
		//	set
		//	{
		//		if(recipes != value)
		//		{
		//			recipes = value;
		//			NotifyPropertyChange(nameof(Recipes));
		//		}
		//	}

		//}

		public RecipeViewModel()
		{
            recipeRepository = new RecipeRepository();
            LoadAllRecipes();

        }

		private async Task LoadAllRecipes()
		{
            Recipes.Clear();
			var allRecipes = await recipeRepository.GetAllRecipes();

            //Recipes = new ObservableCollection<RecipeModel>(allRecipes);

			foreach(var recipe in allRecipes)
			{
				Recipes.Add(recipe);
			}
			Console.WriteLine(Recipes);
		}

		//private void NotifyPropertyChange(string propertyName)
		//{
		//	PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		//}
	}
}

