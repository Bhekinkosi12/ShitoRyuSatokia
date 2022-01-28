using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using ShitoRyuSatokia.Models.MicroModel;


namespace ShitoRyuSatokia.Services
{
    public class UserAuthService
    {
        string APIKEY = "AIzaSyBeDXvk3UC_Wj5WUf8ylIFYfH3nA-5tCcQ";
       static bool isAuth = false;
        public UserAuthService()
        {
         
          
        }



        public async Task<string> Login(string email, string password)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(APIKEY));
         

            try
            {


                var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);


                var content = await auth.GetFreshAuthAsync();


                isAuth = true;


                return await Task.FromResult(content.FirebaseToken);
            }
            catch
            {
                return await Task.FromResult(string.Empty);
            }

        }



        public async Task<string> Signup(string email, string password)
        {

            try
            {

                //  var authProvider = new FirebaseAuthProvider();



                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(APIKEY));

                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);

                string getToken = auth.FirebaseToken;



                isAuth = true;


                return await Task.FromResult(getToken);
            }
            catch
            {


                return await Task.FromResult(string.Empty);
            }


        }


        public async Task<bool> ResetPass(string email)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(APIKEY));

               await authProvider.SendPasswordResetEmailAsync(email);
                return true;
            }
            catch
            {
                return false;
            }
        }






        public bool IsAuth()
        {
            return isAuth;
        }


    }
}
