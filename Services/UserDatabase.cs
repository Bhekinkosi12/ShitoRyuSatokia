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

        public async Task UpdateDojo(Dojo dojo)
        {
            try
            {
                var selectedDojo = (await client.Child("Dojos").OnceAsync<Dojo>()).Where(x => x.Object.ID == dojo.ID).FirstOrDefault();

                await client.Child("Dojos").Child(selectedDojo.Key).PutAsync(dojo);

            }
            catch
            {

            }
        }

        public async Task<bool> AddDojoAsync(Dojo dojo)
        {
            try
            {
                await client.Child("Dojos").PostAsync(dojo);

                return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(true);

            }
        }

        public async Task DeleteDojo(Dojo dojo)
        {
            try
            {
                var item = (await client.Child("Dojos").OnceAsync<Dojo>()).Where(x => x.Object.ID == dojo.ID).FirstOrDefault();


                await client.Child("Dojos").Child(item.Key).DeleteAsync();
            }
            catch
            {

            }
        }



        public async Task AddNews(News news)
        {

            try
            {
                await client.Child("News").PostAsync(news);
            }
            catch
            {

            }

        }
        
        public async Task<List<Dojo>> GetAllDojos()
        {
            List<Dojo> _list = new List<Dojo>();
            try
            {

                var list = (await client.Child("Dojos").OnceAsync<Dojo>()).ToList();


                foreach(var i in list)
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

        public async Task<List<News>> GetAllNews()
        {
            List<News> newslist = new List<News>();
            try
            {
                var items = await client.Child("News").OnceAsync<News>();
                foreach(var i in items)
                {
                    newslist.Add(i.Object);
                }
                return await Task.FromResult(newslist);
                
            }
            catch
            {
                return newslist;
            }
        }


        public async Task<bool> DeleteNews(News news)
        {

            try
            {
                var item = (await client.Child("News").OnceAsync<News>()).Where(x => x.Object.Id == news.Id).FirstOrDefault();

                await client.Child("News").Child(item.Key).DeleteAsync();


                return await Task.FromResult(true);
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> UpdateNews(News news)
        {

            try
            {
                var item = (await client.Child("News").OnceAsync<News>()).Where(x => x.Object.Id == news.Id).FirstOrDefault();

                await client.Child("News").Child(item.Key).PostAsync(news);


                return await Task.FromResult(true);
            }
            catch
            {
                return false;
            }

        }


        public async Task<bool> AddImages(Images img)
        {
            try
            {
                await client.Child("Images").PostAsync(img);

                return true;
            }
            catch
            {
                return false;
            }
        } 




        /// <summary>
        /// Returns Images or null
        /// </summary>
        /// <returns></returns>
        public async Task<List<Images>> GetAllImages()
        {
            List<Images> images = new List<Images>();

            try
            {
                var items = (await client.Child("Images").OnceAsync<Images>()).ToList();
                foreach(var i in items)
                {
                    images.Add(i.Object);
                }

                return images;

            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Delete Item by ID
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public async Task<bool> DeleteImages(Images img)
        {
            try
            {
                var item = (await client.Child("Images").OnceAsync<Images>()).Where(x => x.Object.ID == img.ID).FirstOrDefault();

                await client.Child("Images").Child(item.Key).DeleteAsync();

                return true;

            }
            catch
            {
                return false;
            }
        }




    }
}
