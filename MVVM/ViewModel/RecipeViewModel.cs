using System;
using System.ComponentModel;
using MovieRecipeMobileAPp.MVVM.Models;

namespace MovieRecipeMobileAPp.MVVM.ViewModel
{
    public class RecipeViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private List<RecipeModel> recipes;

		public List<RecipeModel> Recipes
		{
			get { return recipes; }
			set
			{
				if(recipes != value)
				{
					recipes = value;
					NotifyPropertyChange(nameof(Recipes));
				}
			}

		}

		public RecipeViewModel()
		{
			RecipeRepository repository = new RecipeRepository();
			Recipes = repository.GetAllRecipes();
		}

		private void NotifyPropertyChange(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

