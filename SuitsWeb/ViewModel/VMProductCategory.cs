using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suites.Entities;



namespace SuitsWeb.ViewModel
{
    public class VMProductCategory
    {
        public Prodect Prodect { get; set; }

       public List<Category> categories { get; set; }

    }
}