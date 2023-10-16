using System.Collections.ObjectModel;
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
		public ObservableCollection<RecipeModel> allRecipes = new();


		public RecipeViewModel()
		{
            recipeRepository = new RecipeRepository();
            AllRecipes = new ObservableCollection<RecipeModel>();
            //Recipes = new ObservableCollection<RecipeModel>();

        }

		[RelayCommand]
		public async Task LoadAllRecipes()
		{
            AllRecipes.Clear();
			try
			{
                var allRecipes = await recipeRepository.GetAllRecipes();
				Console.Write(allRecipes);
                foreach (var recipe in allRecipes)
                {
                    AllRecipes.Add(recipe);
				}
                Console.WriteLine("================");
				//Console.WriteLine(Recipes[0].Name);
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


			bool isDeleted = await recipeRepository.RemoveRecipe(selectedRecipe);
			if (isDeleted)
			{
				await Shell.Current.DisplayAlert("Delete", selectedRecipe.Name, "OK");
				AllRecipes.Remove(selectedRecipe);
			}

		}

        [RelayCommand]
        public async void DisplayAction(RecipeModel recipe)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("Recipe", recipe);
                await AppShell.Current.GoToAsync(nameof(CreateRecipePage), navParam);
            }
            else if (response == "Delete")
            {
                var confirmed = await Shell.Current.DisplayAlert("Confirm Delete", $"Are you sure you want to delete the recipe '{recipe.Name}'?", "Yes", "No");
                if(confirmed)
                {
                    var delResponse = await recipeRepository.RemoveRecipe(recipe);
                    if (delResponse)
                    {
                        LoadAllRecipes();
                    }
                }

            }
        }

    }
}

