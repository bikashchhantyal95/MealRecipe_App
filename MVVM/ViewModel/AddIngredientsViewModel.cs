using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MovieRecipeMobileAPp.MVVM.Models;
using static Android.Util.EventLogTags;
using static Java.Util.Jar.Attributes;

namespace MovieRecipeMobileAPp.MVVM.ViewModel
{
    internal partial class AddIngredientsViewModel : ObservableObject
    {

        private readonly RecipeRepository recipeRepository;



        public AddIngredientsViewModel()
		{
            recipeRepository = new RecipeRepository();
        }

        private async Task SaveRecipeToDatabaseAsync(object obj)
        {
            
            

        }
    }
}

