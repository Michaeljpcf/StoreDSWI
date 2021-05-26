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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable(string search, int? pageNo)
        {
            ProductSearchViewModel model = new ProductSearchViewModel();

            //"anterior"
            model.PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            ////Similar a la "anterior"
            //if (pageNo.HasValue)
            //{
            //    if (pageNo.Value > 0)
            //    {
            //        model.PageNo = pageNo.Value;
            //    }
            //    else
            //    {
            //        model.PageNo = 1;
            //    }
            //}
            //else
            //{
            //    model.PageNo = 1;
            //}

            model.Products = ProductsService.Instance.GetProducts(model.PageNo);

            if (string.IsNullOrEmpty(search) == false)
            {
                model.SearchTerm = search;
                model.Products = model.Products.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            return PartialView(model);
        }

        //CREAR
        [HttpGet]
        public ActionResult Create()
        {
            NewProductViewModel model = new NewProductViewModel();
            model.AvailableCategories = CategoriesService.Instance.GetCategories();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(NewProductViewModel model)
        {
            var newProduct = new Product();

            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
            newProduct.Category = CategoriesService.Instance.GetCategory(model.CategoryID);
            newProduct.ImageURL = model.ImageURL;

            ProductsService.Instance.SaveProduct(newProduct);
            return RedirectToAction("ProductTable");
        }

        //ACTUALIZAR
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditProductViewModel model = new EditProductViewModel();
            var product = ProductsService.Instance.GetProduct(ID);

            model.ID = product.ID;
            model.Name = product.Name;
            model.Description = product.Description;
            model.Price = product.Price;
            model.CategoryID = product.Category != null ? product.Category.ID : 0;
            model.ImageURL = product.ImageURL;

            model.AvailableCategories = CategoriesService.Instance.GetCategories();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditProductViewModel model)
        {
            var existingProduct = ProductsService.Instance.GetProduct(model.ID);
            existingProduct.Name = model.Name;
            existingProduct.Description = model.Description;
            existingProduct.Price = model.Price;
            existingProduct.Category = CategoriesService.Instance.GetCategory(model.CategoryID);
            existingProduct.ImageURL = model.ImageURL;

            ProductsService.Instance.UpdateProduct(existingProduct);

            return RedirectToAction("ProductTable");
        }

        //ELIMINAR
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            ProductsService.Instance.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }
    }
}