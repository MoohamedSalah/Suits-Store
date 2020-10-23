using Suites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuitsWeb.ViewModel
{
    public class OrdersViewModel
    {
        public string UserID { get; internal set; }
        public string Status { get; internal set; }
        public List<Order> Orders { get; internal set; }
        public Pager Pager { get; internal set; }
    }
}