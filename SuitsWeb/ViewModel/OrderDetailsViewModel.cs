using Suites.Entities;
using SuitsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuitsWeb.ViewModel
{
    public class OrderDetailsViewModel
    {
        public Order Order { get; internal set; }

        public ApplicationUser OrderBy { get; set; }
        public List<string> AvailableStatuses { get; internal set; }
    }
}