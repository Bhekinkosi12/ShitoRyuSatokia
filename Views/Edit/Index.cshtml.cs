using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShitoRyuSatokia.Models;
using ShitoRyuSatokia.Models.MicroModel;

namespace ShitoRyuSatokia.Views.Edit
{
    public class IndexModel : PageModel
    {
        public List<Dojo> DojoList { get; set; } = new List<Dojo>();
        public void OnGet()
        {
            AdminViewModel adminViewModel = new AdminViewModel();
           // DojoList = adminViewModel.DojoList;
        }

        public IndexModel()
        {
            AdminViewModel adminViewModel = new AdminViewModel();
           // DojoList = adminViewModel.DojoList;

        }

    }
}
