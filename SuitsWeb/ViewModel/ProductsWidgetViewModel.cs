using Suites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuitsWeb.ViewModel
{
    public class ProductsWidgetViewModel
    {
        public List<Prodect> Products { get; set; }
        public bool IsLatestProducts { get; set; }
    }
}