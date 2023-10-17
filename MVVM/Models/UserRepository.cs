using System;
using Firebase.Database;

namespace MovieRecipeMobileAPp.MVVM.Models
{
	public class UserRepository
	{
        private readonly FirebaseClient firebaseClient;

        public UserRepository()
		{
            firebaseClient = new FirebaseClient(FirebaseConfig.firebaseDatabaseUrl);
        }
	}
}

