using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Suites.Serveres;
using SuitsWeb.ViewModel;

namespace SuitsWeb.Controllers
{
    public class ShopController : Controller
    {
        ProdectServes ProdectServes = new ProdectServes();
        public ActionResult Checkout()
        {
            VMCheckout  model = new VMCheckout();

            var CartProductsCookie = Request.Cookies["CartProducts"];

            if (CartProductsCookie != null)
            {
                //var productIDs = CartProductsCookie.Value;
                //var ids = productIDs.Split('-');
                //List<int> pIDs = ids.Select(x => int.Parse(x)).ToList();

                model.CartProductIDs = CartProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();

                model.CartProducts = ProdectServes.GetProducts(model.CartProductIDs);
            }

            return View(model);
        }
    }
}