using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//
using StoreDSWI.Entities;
using StoreDSWI.Services;
using StoreDSWI.Web.ViewModels;

namespace StoreDSWI.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductsService productsService = new ProductsService();
        CategoriesService categoriesService = new CategoriesService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable(string search)
        {
            var products = productsService.GetProducts();

            if (string.IsNullOrEmpty(search) == false)
            {
                products = products.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            return PartialView(products);
        }

        //CREAR
        [HttpGet]
        public ActionResult Create()
        {            
            var categories = categoriesService.GetCategories();
            return PartialView(categories);
        }

        [HttpPost]
        public ActionResult Create(NewCategoryViewModel model)
        {
            var newProduct = new Product();

            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
            newProduct.Category = categoriesService.GetCategory(model.CategoryID);

            productsService.SaveProduct(newProduct);
            return RedirectToAction("ProductTable");
        }

        //ACTUALIZAR
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var product = productsService.GetProduct(ID);

            return PartialView(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            productsService.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }

        //ELIMINAR
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            productsService.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }
    }
}