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

            _dojo.Dojo_Instructor_Image =  item;

                item = null;

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

                _news.Cover_Image =  imgData;

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
            string link;



            if (dojo.InstructorImage != null)
            {
                var filepath = Path.GetTempFileName();
                var a = dojo.InstructorImage;
                using (var stream = a.OpenReadStream())
                {

                    
                    
                    
                    var item = await userStorage.AddStoreStream(dojo.InstructorImage.FileName, (FileStream)stream );

                    // _dojo.Dojo_Instructor_Image = item;
                    link = item;


                }


                Dojo _dojo = new Dojo()
                {
                     Dojo_Description = dojo.Dojo_Description,
                      Dojo_Instructor_Description = dojo.Dojo_Instructor_Description,
                       Dojo_Instructor = dojo.Dojo_Instructor,
                        Dojo_Instructor_Email = dojo.Dojo_Instructor_Email,
                         Dojo_Instructor_Image = link,
                          Dojo_Instructor_Number = dojo.Dojo_Instructor_Number,
                           Dojo_Instructor_Position = dojo.Dojo_Instructor_Position,
                            Dojo_Instructor_Surname = dojo.Dojo_Instructor_Surname,
                             Dojo_Name = dojo.Dojo_Name,
                              Dojo_Schedule = dojo.Dojo_Schedule,
                               Dojo_Time = dojo.Dojo_Time,
                                ID = dojo.ID,
                                 location = dojo.location,
                                  Regulation = dojo.Regulation
                };






                await userDatabase.AddDojoAsync(_dojo);

            }
            else
            {

                await userDatabase.AddDojoAsync(dojo);

            }


        }

        public async void AddNews(News news)
        {
            UserDatabase userDatabase = new UserDatabase();
            UserStorage userStorage = new UserStorage();


           

            if (news.Image != null)
            {

              //  var imag = news.Image.OpenReadStream();



                var filepath = Path.GetTempFileName();
                

                using (var stream = File.Create(filepath))
                {

                    var a = news.Image;
                    await a.CopyToAsync(stream);

                    var imgData = await userStorage.AddStoreStream(news.Image.FileName, stream);
                    // _dojo.Dojo_Instructor_Image = item;
                   


                }





               
                

                // _news.Cover_Image = await imgData;

                // _news.Image = null;


                News _news = new News()
                {
                     Brief = news.Brief,
                      Date = news.Date,
                       Description = news.Description,
                        heading = news.heading,
                         Id = news.Id,
                          IsNew = news.IsNew,
                          

                };








                await userDatabase.AddNews(_news);


            }
            else
            {
                await userDatabase.AddNews(news);
            }
        }






    }
}
