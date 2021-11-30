using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


using System.Threading.Tasks;
using ShitoRyuSatokia.Services;
using ShitoRyuSatokia.Models.MicroModel;
using Microsoft.AspNetCore.Hosting;

namespace ShitoRyuSatokia.Models
{
    public class PostViewModel 
    {

        IHostingEnvironment env;


        public PostViewModel()
        {



        }
      






        public async void UpdateDojo(Dojo dojo)
        {
            UserDatabase userDatabase = new UserDatabase();
            UserStorage userStorage = new UserStorage();
            Dojo _dojo = dojo;

            if(dojo.InstructorImage != null)
            {

           var stream =  dojo.InstructorImage.OpenReadStream();


           var item = await userStorage.AddStoreStream(dojo.InstructorImage.FileName, stream);

            _dojo.Dojo_Instructor_Image = item;



                await userDatabase.UpdateDojo(_dojo);

            }
            else
            {

                await userDatabase.UpdateDojo(_dojo);

            }
           
            

        }

        public async void UpDateNews(News news)
        {
            UserDatabase userDatabase = new UserDatabase();
            UserStorage userStorage = new UserStorage();


            News _news = news;

            if(news.Image != null)
            {

                var imag = news.Image.OpenReadStream();


              var imgData = await userStorage.AddStoreStream(news.Image.FileName, imag);

                _news.Cover_Image = imgData;

                _news.Image = null;


                await userDatabase.UpdateNews(_news);


            }
            else
            {
                await userDatabase.UpdateNews(_news);
            }





        }


        public async void AddDojo(Dojo dojo)
        {
            UserDatabase userDatabase = new UserDatabase();
            UserStorage userStorage = new UserStorage();
            Dojo _dojo = dojo;

            if (dojo.InstructorImage != null)
            {

                var stream = dojo.InstructorImage.OpenReadStream();


                var item = await userStorage.AddStoreStream(dojo.InstructorImage.FileName, stream);

                _dojo.Dojo_Instructor_Image = item;



                await userDatabase.AddDojoAsync(_dojo);

            }
            else
            {

                await userDatabase.AddDojoAsync(_dojo);

            }


        }

        public async void AddNews(News news)
        {
            UserDatabase userDatabase = new UserDatabase();
            UserStorage userStorage = new UserStorage();


            News _news = news;

            if (news.Image != null)
            {

                var imag = news.Image.OpenReadStream();


                var imgData = await userStorage.AddStoreStream(news.Image.FileName, imag);

                _news.Cover_Image = imgData;

                _news.Image = null;


                await userDatabase.AddNews(_news);


            }
            else
            {
                await userDatabase.AddNews(_news);
            }
        }






    }
}
