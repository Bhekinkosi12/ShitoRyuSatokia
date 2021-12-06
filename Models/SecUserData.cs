using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Storage;
using Firebase.Database.Query;
using ShitoRyuSatokia.Models.MicroModel;
using System.IO;

namespace ShitoRyuSatokia.Models
{

    public class SecUserData
    {
        FirebaseClient client;

        public SecUserData()
        {
            client = new FirebaseClient("https://shitoryukarate-ea3d5-default-rtdb.firebaseio.com/");
        }

        public FirebaseStorageTask AddStoreStream(string name, Stream stream)
        {
            return new FirebaseStorage("shitoryukarate-ea3d5.appspot.com")
                .Child("Compony")

                .Child(name)
                .PutAsync(stream);




        }

        public async Task<List<Dojo>> GetAllDojos()
        {
            List<Dojo> _list = new List<Dojo>();
            try
            {

                var list = (await client.Child("Dojos").OnceAsync<Dojo>()).ToList();


                foreach (var i in list)
                {
                    _list.Add(i.Object);
                }

                return await Task.FromResult(_list);

            }
            catch
            {
                return _list;
            }

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

        public async Task<bool> DeleteRequest(Dojo dojo)
        {
            try
            {
                var sele = (await client.Child("Requests").OnceAsync<Dojo>()).Where(x => x.Object.ID == dojo.ID).FirstOrDefault();


                await client.Child("Requests").Child(sele.Key).DeleteAsync();


                return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(true);

            }
        }

        public async Task<List<Dojo>> GetDojoRequest()
        {
            List<Dojo> dojolist = new List<Dojo>();
            try
            {

                var lists = (await client.Child("Requests").OnceAsync<Dojo>()).ToList();

                foreach (var i in lists)
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
