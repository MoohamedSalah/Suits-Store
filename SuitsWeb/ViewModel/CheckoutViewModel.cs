using Suites.Entities;
using SuitsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuitsWeb.ViewModel
{
    public class CheckoutViewModel
    {
        public List<int> CartProductIDs { get; set; }
        public List<Prodect> CartProducts { get; set; }
        public ApplicationUser User { get; set; }
    }
}