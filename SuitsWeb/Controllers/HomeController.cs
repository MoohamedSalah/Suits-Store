using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Suites.Serveres;
using SuitsWeb;
using SuitsWeb.ViewModel;

namespace SuitsWeb.Controllers
{
    public class HomeController : Controller
    {
      
        CatagorySereves CatagorySereves = new CatagorySereves();
        public ActionResult Index()
        {
            var vMCategotryPoductHome = new VMCategotryPoductHome();

            vMCategotryPoductHome.FeaturedCategories = CatagorySereves.GetCategoriesFeature();


            return View(vMCategotryPoductHome);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}