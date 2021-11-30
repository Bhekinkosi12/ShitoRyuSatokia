using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ShitoRyuSatokia.Models.MicroModel
{
    public class News
    {

        public string Id { get; set; }
        public string Cover_Image { get; set; }
        public string heading { get; set; }
        public string Brief { get; set; }
        public DateTime Date { get; set; }
        public IFormFile Image { get; set; }
        public string Description { get; set; }
        public string IsNew { get; set; }
        public List<IMG> EventImages { get; set; }

        


    }
    public class IMG
    {
        public string Id { get; set; }
        public string URL { get; set; }
    }
}
