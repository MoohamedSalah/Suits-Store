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
        ProdectServes ProductsService = new ProdectServes();
        CatagorySereves CategoriesService = new CatagorySereves();
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

                model.CartProducts = ProductsService.GetProducts(model.CartProductIDs);
            }

            return View(model);
        }

        public ActionResult Index(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy)
        {
            ShopViewModel model = new ShopViewModel();

            model.FeaturedCategories = CategoriesService.GetCategoriesFeature();

            model.MaximumPrice = ProductsService.GetMaximumPrice();

            model.Products = ProductsService.SearchProducts(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy);

            model.SortBy = sortBy;

            return View(model);
        }

        public ActionResult FilterProducts(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy)
        {
            FilterProductsViewModel model = new FilterProductsViewModel();

            model.Products = ProductsService.SearchProducts(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy);

            return PartialView(model);
        }


    }
}