using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShitoRyuSatokia.Models.MicroModel
{
    public class Instructor
    {

        public string ID { get; set; }
        public string Code { get; set; }
        public string Email { get; set; } 
        public string Number { get; set; }
        public string Image { get; set; }
        public string DojoName { get; set; }
        public List<Student> Students { get; set; }


    }
}
