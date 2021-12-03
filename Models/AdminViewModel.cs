using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShitoRyuSatokia.Models.MicroModel;
using ShitoRyuSatokia.Services;

namespace ShitoRyuSatokia.Models
{
    public class AdminViewModel
    {

       public List<Dojo> DojoList { get; set; }
        public List<News> NewsList { get; set; }

        public  Dojo SelectedDojo { get; set; }
        public  News SelectedNews { get; set; }



        public AdminViewModel(bool IsFirstRoute = true)
        {
            onDemoData();
            getDojos();
            if (!IsFirstRoute)
            {
                List<Dojo> dojolist = new List<Dojo>();
                foreach(var i in DojoList)
                {
                    i.Dojo_Instructor_Image = $"../{i.Dojo_Instructor_Image}";
                    dojolist.Add(i);
                }
                DojoList = dojolist;
            }
            
        }

        public AdminViewModel(string SelectedDojoName, bool IsNews = false)
        {

            if (!IsNews)
            {

                SelectedDojo = new Dojo();
                onDemoData();



                var dojo = DojoList.Where(x => x.Dojo_Name == SelectedDojoName).FirstOrDefault();

                SelectedDojo = dojo;
            }
            else
            {
                SelectedNews = new News();
                onDemoData();

                var news = NewsList.Where(x => x.Id == SelectedDojoName).FirstOrDefault();
                SelectedNews = news;
            }

        }

        public Dojo ReturnDojo()
        {

            return SelectedDojo;
        }

        public News ReturnNews()
        {
            return SelectedNews;
        }
       




       async void getNewsData()
        {
                onDemoData();
            UserDatabase userDatabase = new UserDatabase();
            var list = await userDatabase.GetAllNews();
            


            if(list.Count != 0)
            {
                NewsList = list;
            }
            else
            {
            }



        }




        async void getDojos()
        {
            UserDatabase userDatabase = new UserDatabase();

            DojoList = new List<Dojo>();


            DojoList = await userDatabase.GetAllDojos();
           



        }



        void onDemoData()
        {
            /*
            DojoList = new List<Dojo>()
            {
                new Dojo
                {
                     Dojo_Name = "Sasol Club Recreation center",
                      location = "Mpumalanga Secunda Embalenhle ext5",
                       Dojo_Instructor = "Joseph Sensei",
                        Dojo_Instructor_Description = "National Coach",
                         Dojo_Instructor_Image = "images/off1.png",
                          Dojo_Instructor_Position = "4th Dan",
                           Dojo_Description = "Sasol Recreational center is a club were karate is practiced with a bunch of other.",
                            ID = Guid.NewGuid().ToString(),
                             Regulation = "",
                              Dojo_Schedule = new Dictionary<string, string>()
                              {
                                  
                              }
                },
                   new Dojo
                {
                     Dojo_Name = "Dojo Name",
                      location = "Mpumalanga Secunda Embalenhle ext5",
                       Dojo_Instructor = "Obtri Murwe",
                        Dojo_Instructor_Description = "National co-ordinator",
                         Dojo_Instructor_Image = "images/off4.png",
                          Dojo_Instructor_Position = "4th Dan",
                           Dojo_Description = "Sasol Recreational center is a club were karate is practiced with a bunch of other.",
                            ID = Guid.NewGuid().ToString(),
                             Regulation = "",
                              Dojo_Schedule = new Dictionary<string, string>()
                              {

                              }
                },
                      new Dojo
                {
                     Dojo_Name = "Sasol Club Recreation center",
                      location = "Mpumalanga Secunda Embalenhle ext5",
                       Dojo_Instructor = "Sydney Hoaeane",
                        Dojo_Instructor_Description = "Chief Instructor",
                         Dojo_Instructor_Image = "images/off3.png",
                          Dojo_Instructor_Position = "6th Dan",
                           Dojo_Description = "Sasol Recreational center is a club were karate is practiced with a bunch of other.",
                            ID = Guid.NewGuid().ToString(),
                             Regulation = "",
                              Dojo_Schedule = new Dictionary<string, string>()
                              {

                              }
                },
                       new Dojo
                {
                     Dojo_Name = "Sasol Club Recreation center",
                      location = "Mpumalanga Secunda Embalenhle ext5",
                       Dojo_Instructor = "Sensei Mduduzi",
                        Dojo_Instructor_Description = "Head Sensei",
                         Dojo_Instructor_Image = "images/off2.png",
                          Dojo_Instructor_Position = "6th Dan",
                           Dojo_Description = "Sasol Recreational center is a club were karate is practiced with a bunch of other.",
                            ID = Guid.NewGuid().ToString(),
                             Regulation = "",
                              Dojo_Schedule = new Dictionary<string, string>()
                              {

                              }
                }
            };

            */


            NewsList = new List<News>()
            {
                new News
                {
                     Id = "awe",
                      Brief = "Shito kai South Africa students were grading and changing their rankings.",
                       Description = "In November 2021 the head of shito ryu satoha  ",
                        Cover_Image = "../images/off1.png",
                         EventImages = new List<IMG>()
                         {
                              new IMG
                              {
                                   Id = Guid.NewGuid().ToString(),
                                    URL = "../images/off1.png"
                              },
                               new IMG
                              {
                                   Id = Guid.NewGuid().ToString(),
                                    URL = "../images/off2.png"
                              },
                                new IMG
                              {
                                   Id = Guid.NewGuid().ToString(),
                                    URL = "../images/off3.png"
                              }
                         },
                         
                          heading = "Senior Grading Section"
                },

                 new News
                {
                     Id = "awe1",
                      Brief = "Shito kai South Africa students were grading and changing their rankings.",
                       Description = "In November 2021 the head of shito ryu satoha  ",
                        Cover_Image = "../images/off3.png",
                         EventImages = new List<IMG>()
                         {
                              new IMG
                              {
                                   Id = Guid.NewGuid().ToString(),
                                    URL = "../images/off1.png"
                              },
                               new IMG
                              {
                                   Id = Guid.NewGuid().ToString(),
                                    URL = "../images/off2.png"
                              },
                                new IMG
                              {
                                   Id = Guid.NewGuid().ToString(),
                                    URL = "../images/off3.png"
                              }
                         }
                         ,
                          heading = "Senior Grading Section"
                }

                 ,

                 new News
                {
                     Id = "awe2",
                      Brief = "Shito kai South Africa students were grading and changing their rankings.",
                       Description = "In November 2021 the head of shito ryu satoha  ",
                        Cover_Image = "../images/off2.png",
                         EventImages = new List<IMG>()
                         {
                              new IMG
                              {
                                   Id = Guid.NewGuid().ToString(),
                                    URL = "../images/off1.png"
                              },
                               new IMG
                              {
                                   Id = Guid.NewGuid().ToString(),
                                    URL = "../images/off2.png"
                              },
                                new IMG
                              {
                                   Id = Guid.NewGuid().ToString(),
                                    URL = "../images/off3.png"
                              }
                         },
                          heading = "Senior Grading Section"
                }

            };


        }




    }
}
