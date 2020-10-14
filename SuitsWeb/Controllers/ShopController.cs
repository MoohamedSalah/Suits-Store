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

        public ActionResult Index(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int? pageNo)
        {
            var pageSize = ConfigurationsService.Instance.ShopPageSize();

            ShopViewModel model = new ShopViewModel();

            model.SearchTerm = searchTerm;
            model.FeaturedCategories = CategoriesService.GetFeaturedCategories();
            model.MaximumPrice = ProductsService.GetMaximumPrice();

            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.SortBy = sortBy;
            model.CategoryID = categoryID;

            int totalCount = ProductsService.SearchProductsCount(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy);
            model.Products = ProductsService.SearchProducts(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy, pageNo.Value, pageSize);

            model.Pager = new Pager(totalCount, pageNo, (int)pageSize);

            return View(model);
        }

      

        public ActionResult FilterProducts(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int? pageNo)
        {
            var pageSize = ConfigurationsService.Instance.ShopPageSize();

            FilterProductsViewModel model = new FilterProductsViewModel();

            model.SearchTerm = searchTerm;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            model.SortBy = sortBy;
            model.CategoryID = categoryID;

            int totalCount = ProductsService.SearchProductsCount(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy);
            model.Products = ProductsService.SearchProducts(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy, pageNo.Value, pageSize);

            model.Pager = new Pager(totalCount, pageNo, (int)pageSize);

            return PartialView(model);
        }



    }
}