using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieRecipeMobileAPp.MVVM.Models;
using MovieRecipeMobileAPp.MVVM.View;

namespace MovieRecipeMobileAPp.MVVM.ViewModel
{
    internal partial class RecipeViewModel : ObservableObject
	{
		//public event PropertyChangedEventHandler PropertyChanged;

        private readonly RecipeRepository recipeRepository;

		[ObservableProperty]
		public ObservableCollection<RecipeModel> recipes = new();


		public RecipeViewModel()
		{
            recipeRepository = new RecipeRepository();
			Recipes = new ObservableCollection<RecipeModel>();

        }

		public async Task LoadAllRecipes()
		{
            Recipes.Clear();
			try
			{
                var allRecipes = await recipeRepository.GetAllRecipes();
				Console.Write(allRecipes);
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
			
        }
		[RelayCommand]
		public async void GoToDetailspage(RecipeModel selectedRecipe)
		{
			var detailsViewModel = new RecipeDetailsViewModel(selectedRecipe);
			var detailspage = new RecipeDetailPage(detailsViewModel);
			await Shell.Current.Navigation.PushAsync(detailspage);

        }

        [RelayCommand]
        public async void DeleteRecipe(RecipeModel selectedRecipe)
        {
			if (selectedRecipe == null)
				return;
			

			bool isDeleted = await recipeRepository.RemoveRecipe(selectedRecipe.Id);
			if (isDeleted)
			{
				await Shell.Current.DisplayAlert("Delete", selectedRecipe.Name, "OK");
				Recipes.Remove(selectedRecipe);
			}

        }
    }
}

