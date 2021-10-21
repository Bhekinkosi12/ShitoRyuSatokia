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
        FirebaseClient client;
        static string token;
        public UserAuthService()
        {
         
            client = new FirebaseClient("https://shitoryukarate-ea3d5-default-rtdb.firebaseio.com/");
        }


       async  Task<bool> AddDojo(Dojo dojo)
        {
            try
            {
                await client.Child("Dojos").PostAsync(dojo);
              return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }


        public async Task SignupTODbAsync(string email,string password)
        {
           
        }
        public async Task<List<Dojo>> GetAllDojos()
        {
            List<Dojo> dojolist = new List<Dojo>();
            try
            {

            var items = await client.Child("Dojos").OnceAsync<Dojo>();
            }
            catch
            {
                dojolist = null;
            }

            return await Task.FromResult(dojolist);
        } 


        


    }
}
