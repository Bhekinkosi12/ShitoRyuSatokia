using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShitoRyuSatokia.Models.MicroModel;
using ShitoRyuSatokia.Services;

namespace ShitoRyuSatokia.Models
{

    
    public class JoinViewModel
    {

        public static Dojo SelectedDojo { get; set; } = new Dojo();

        public  Dojo SelectDojo { get; set; }


        public JoinViewModel()
        {
            SelectDojo = SelectedDojo;
            
        }



       public void SetData(Dojo _dojo)
        {
            SelectedDojo = _dojo;
        }





    }






}
