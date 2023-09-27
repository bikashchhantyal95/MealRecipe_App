using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Database;
using Firebase.Database.Query;
using MovieRecipeMobileAPp.MVVM.Models;

namespace MovieRecipeMobileAPp.MVVM.ViewModel
{
    internal partial class CreateRecipeViewModel : ObservableObject
    {
		public CreateRecipeViewModel()
		{
            CreateRecipe = new Command(CreateRecipeBtnTapped);
		}

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string instructions;

        public Command CreateRecipe { get; }

        private async void CreateRecipeBtnTapped(object obj)
        {
            await SaveRecipeToDatabaseAsync(obj);
        }

        private async Task SaveRecipeToDatabaseAsync(object obj)
        {
            string firebaseDatabaseUrl = "https://recipebook-5d5d2-default-rtdb.firebaseio.com/";

            FirebaseClient firebaseClient = new FirebaseClient(firebaseDatabaseUrl);
            try
            {
                var res = await firebaseClient.Child("Recipe").PostAsync(
                    new RecipeModel
                    {
                        Name = Name,
                        Description = Description,
                        Instructions = Instructions
                    }
                    );
                Console.WriteLine("Data has been added successfully");
            }
            catch(Exception e)
            {

            }

        }
    }
}

