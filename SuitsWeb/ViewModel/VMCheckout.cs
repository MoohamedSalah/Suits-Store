using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suites.Entities;

namespace SuitsWeb.ViewModel
{
    public class VMCheckout
    {
        public List<int> CartProductIDs { get;  set; }
        public List<Prodect>  CartProducts { get;  set; }
    }
}