using ShitoRyuSatokia.Models.MicroModel;
using ShitoRyuSatokia.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShitoRyuSatokia.Models
{
    public class AdminViewModel
    {

        public ObservableCollection<Dojo> DojoList { get; set; }
        public List<News> NewsList { get; set; }

        public Dojo SelectedDojo { get; set; }
        public News SelectedNews { get; set; }



        public AdminViewModel(bool IsFirstRoute = true)
        {
            onDemoData();
            

            if (!IsFirstRoute)
            {
                ObservableCollection<Dojo> dojolist = new ObservableCollection<Dojo>();
                foreach (var i in DojoList)
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



            if (list.Count != 0)
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

            ObservableCollection<Dojo> dojos = new ObservableCollection<Dojo>();
            DojoList = new ObservableCollection<Dojo>();


           var  _dojos = await userDatabase.GetAllDojos();

            foreach(var i in _dojos)
            {
                dojos.Add(i);
                DojoList.Add(i);
            }

          //  DojoList = dojos;


        }



        void onDemoData()
        {
           // getDojos();
            
            DojoList = new ObservableCollection<Dojo>()
            {
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
                     Dojo_Name = "Dojo Name",
                      location = "Mpumalanga Secunda Embalenhle ext5",
                       Dojo_Instructor = "Aubrey Murwe",
                        Dojo_Instructor_Description = "National co-ordinator",
                         Dojo_Instructor_Image = "images/off4.png",
                          Dojo_Instructor_Position = "5th Dan",
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
                       Dojo_Instructor = "Joseph Mthimuye",
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
                     Dojo_Name = "Sasol Club Recreation center",
                      location = "Mpumalanga Secunda Embalenhle ext5",
                       Dojo_Instructor = "Mduduzi Ncube",
                        Dojo_Instructor_Description = "Head Sensei",
                         Dojo_Instructor_Image = "images/off2.png",
                          Dojo_Instructor_Position = "3th Dan",
                           Dojo_Description = "Sasol Recreational center is a club were karate is practiced with a bunch of other.",
                            ID = Guid.NewGuid().ToString(),
                             Regulation = "",
                              Dojo_Schedule = new Dictionary<string, string>()
                              {

                              }
                }
            };

          


            NewsList = new List<News>()
            {
                new News
                {
                     Id = "awe",
                     Date = new DateTime(2021,09,26),
                      Brief = "Shitoryu Satokai South Africa hosting a grading session",
                       Description = "In September 2021 Shitoryu Satokai South Africa Satoha Shitoryu International Federation Hosted het another grgading session for all registered students within the federation. \n\n The head coach was proud to announce the results of how the hard working students performed within the grading process. \n\n New students have joined the federation said head coach Shihan Sydney, 'New dojos have joined us from within the country Africa'. Students were taught at their arrival the skills required to win.    ",
                        Cover_Image = "../images/news1.jpg",
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

                          heading = "Grading Session"
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
