﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using ShitoRyuSatokia.Models.MicroModel;

namespace ShitoRyuSatokia.Services
{
    public class UserDatabase
    {

        FirebaseClient client;

        public UserDatabase()
        {
            client = new FirebaseClient("https://shitoryukarate-ea3d5-default-rtdb.firebaseio.com/");
        }



        public async Task<bool> AddRequest(Dojo dojo)
        {

            try
            {

                await client.Child("Requests").PostAsync(dojo);




                return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(false);
            }

        }
        public async Task<List<Dojo>> GetDojoRequest()
        {
            List<Dojo> dojolist = new List<Dojo>();
            try
            {

                var lists = await client.Child("Requests").OnceAsync<Dojo>();

                foreach(var i in lists)
                {
                    dojolist.Add(i.Object);
                }

                return await Task.FromResult(dojolist);
            }
            catch
            {
                return null;
            }
        }





    }
}