using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suites.Entities;

namespace SuitsWeb.ViewModel
{
    public class ShopViewModel
    {
        public List<Category> FeaturedCategories { get;  set; }
        public int MaximumPrice { get;  set; }
        public List<Prodect>  Products { get;  set; }
        public int? SortBy { get; set; }
    }
}