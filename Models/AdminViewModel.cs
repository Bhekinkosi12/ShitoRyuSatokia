using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShitoRyuSatokia.Models.MicroModel;

namespace ShitoRyuSatokia.Models
{
    public class AdminViewModel
    {

       public List<Dojo> DojoList { get; set; }

        public Dojo SelectedDojo { get; set; }



        public AdminViewModel()
        {
            onDemoData();
        }

        public AdminViewModel(string SelectedDojoName)
        {
            SelectedDojo = new Dojo();
            onDemoData();



            var dojo = DojoList.Where(x => x.Dojo_Name == SelectedDojoName).FirstOrDefault();

            SelectedDojo = dojo;

        }



        void onDemoData()
        {
            DojoList = new List<Dojo>()
            {
                new Dojo
                {
                     Dojo_Name = "Sasol Club Recreation center",
                      location = "Mpumalanga Secunda Embalenhle ext5",
                       Dojo_Instructor = "Joseph Sensei",
                        Dojo_Instructor_Description = "Joseph Sensei is the head of Sasol Recreational center. The head couch of Mpumalanga in Karate South Africa.",
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
                       Dojo_Instructor = "Joseph Sensei",
                        Dojo_Instructor_Description = "Joseph Sensei is the head of Sasol Recreational center. The head couch of Mpumalanga in Karate South Africa.",
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
                       Dojo_Instructor = "Joseph Sensei",
                        Dojo_Instructor_Description = "Joseph Sensei is the head of Sasol Recreational center. The head couch of Mpumalanga in Karate South Africa.",
                         Dojo_Instructor_Image = "images/off1.png",
                          Dojo_Instructor_Position = "4th Dan",
                           Dojo_Description = "Sasol Recreational center is a club were karate is practiced with a bunch of other.",
                            ID = Guid.NewGuid().ToString(),
                             Regulation = "",
                              Dojo_Schedule = new Dictionary<string, string>()
                              {

                              }
                }
            };
        }




    }
}
