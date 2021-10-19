using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;


namespace ShitoRyuSatokia.Services
{
    public class UserAuthService
    {
        FirebaseClient client;
        public UserAuthService()
        {
           
            client = new FirebaseClient("https://shitoryukarate-ea3d5-default-rtdb.firebaseio.com/");
        }



        public async Task SignupTODbAsync(string email,string password)
        {
           
        }
        


    }
}
