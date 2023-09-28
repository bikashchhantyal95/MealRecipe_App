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
            

        }

		public async void LoadAllRecipes()
		{
            Recipes.Clear();
			try
			{
                var allRecipes = await recipeRepository.GetAllRecipes();
                foreach (var recipe in allRecipes)
                {
                    Recipes.Add(recipe);
                }
                Console.WriteLine("================");
				Console.WriteLine(Recipes[0].Name);
                Console.WriteLine("================");
            } catch(Exception e)
			{

			}
			

			//Recipes = new ObservableCollection<RecipeModel>(allRecipes);

			//Recipes = new ObservableCollection<RecipeModel>(allRecipes);
			
        }

		//private void NotifyPropertyChange(string propertyName)
		//{
		//	PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		//}
	}
}

