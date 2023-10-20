using System;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;

namespace MovieRecipeMobileAPp.MVVM.Models
{
	public class UserRepository
	{
        private readonly FirebaseAuthProvider firebaseAuth;

        private readonly FirebaseClient firebaseClient;

        private string WebApiKey = "AIzaSyBtZZIJSNq_MTtpBP7WisAy9yqtkchcFrc";

        public UserRepository()
		{
            firebaseAuth = new FirebaseAuthProvider(new FirebaseConfig(WebApiKey));
            firebaseClient = new FirebaseClient(FirebaseConfiguration.firebaseDatabaseUrl);
        }

        public async Task<string> SignUpAsync(string email, string password)
        {
            try
            {
                var auth = await firebaseAuth.CreateUserWithEmailAndPasswordAsync(email, password);
                //string authToken = response.FirebaseToken;
                return auth.User.LocalId;

            }catch(FirebaseAuthException ex)
            {
                if (ex.Reason == AuthErrorReason.EmailExists)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Email already exists. Please choose a different email.", "OK");
                }
                else if (ex.Reason == AuthErrorReason.InvalidEmailAddress)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Invalid email address. Please enter a valid email.", "OK");
                }
                else if (ex.Reason == AuthErrorReason.WeakPassword)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Weak password. Please choose a stronger password.", "OK");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Registration failed. Please try again.", "OK");
                }
                return null;
            }
        }

        //Add a new user to the firebase database
        public async Task<bool> SaveUserInfoToDatabaseAsync(User user,string userId)
        {
            try
            {
                // user details before adding
                Console.WriteLine($"Adding user: Name={user.FirstName} {user.LastName}");
                var res = await firebaseClient.Child(nameof(User)).Child(userId).PostAsync(user);
              
                Console.WriteLine("User created successfully.");
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding user");
                return false;
            }
        }

        public async void LoginAsync(string email, string password)
        {
            try
            {
                var auth = await firebaseAuth.SignInWithEmailAndPasswordAsync(email, password);
                var content = await auth.GetFreshAuthAsync();
                var serializeContent = JsonConvert.SerializeObject(content);
                Preferences.Set("FirebaseToken", serializeContent);

                await Shell.Current.DisplayAlert("Sucess", "user logged in successfully", "ok");
                
            }catch (FirebaseAuthException e)
            {
                if(e.Reason == AuthErrorReason.UserNotFound)
                {
                    await Shell.Current.DisplayAlert("Failure", "User not found,", "ok");
                }
            }
        }
    }
}

