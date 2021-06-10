using StoreDSWI.Services;
using StoreDSWI.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreDSWI.Web.Controllers
{
    public class WidgetsController : Controller
    {
        // GET: Widgets
        public ActionResult Products(bool isLastestProducts, int ? CategoryID = 0)
        {
            ProductsWidgetViewModels model = new ProductsWidgetViewModels();
            model.IsLatestProducts = isLastestProducts;

            if (isLastestProducts)
            {
                model.Products = ProductsService.Instance.GetLatestProducts(10);
            }
            else if (CategoryID.HasValue && CategoryID.Value > 0)
            {
                model.Products = ProductsService.Instance.GetProductsByCategory(CategoryID.Value, 10);
            }
            else
            {
                model.Products = ProductsService.Instance.GetProducts(1, 10);
            }

            return PartialView(model);
        }
    }
}