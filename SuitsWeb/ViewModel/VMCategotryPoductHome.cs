using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suites.Entities;

namespace SuitsWeb.ViewModel
{
    public class VMCategotryPoductHome
    {
        public List<Prodect> Featuredprodects { get; set; }
        public List<Category> FeaturedCategories { get; internal set; }
    }
}