using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShitoRyuSatokia.Models.MicroModel
{
    public class Dojo
    {

        public string ID { get; set; }
        public string Dojo_Name { get; set; }
        public string Dojo_Instructor { get; set; }
        public string Dojo_Instructor_Email { get; set; }
        public string Dojo_Instructor_Surname { get; set; }
        public string Dojo_Instructor_Number { get; set; }
        public string Dojo_Instructor_Image { get; set;  }
        public string Dojo_Instructor_Position { get; set; }
        public string Dojo_Instructor_Description { get; set;  }
        public string Dojo_Description { get; set; }
        public string Dojo_Time { get; set; }
        public Dictionary<string, string> Dojo_Schedule { get; set; }
        public string location { get; set; }
        public string Regulation { get; set; }
        public IFormFile InstructorImage { get; set; }




    }

}
