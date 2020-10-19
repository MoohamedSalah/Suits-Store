using Suites.Serveres;
using SuitsWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuitsWeb.Controllers
{
    public class WidgestsController : Controller
    {
       
        // GET: Widgets
        public ActionResult Products(bool isLatestProducts, int? CategoryID = 0)
        {
            ProductsWidgetViewModel model = new ProductsWidgetViewModel();
            model.IsLatestProducts = isLatestProducts;

            if (isLatestProducts)
            {
                model.Products = ProdectServes.Instance.GetLatestProducts(4);
            }
            else if (CategoryID.HasValue && CategoryID.Value > 0)
            {
                model.Products =  ProdectServes.Instance.GetProductsByCategory(CategoryID.Value, 4);
            }
            else
            {
                model.Products =  ProdectServes.Instance.GetProducts(1, 8);
            }

            return PartialView(model);
        }
    }
}