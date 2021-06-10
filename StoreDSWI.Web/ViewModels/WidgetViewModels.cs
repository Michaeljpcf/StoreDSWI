using StoreDSWI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreDSWI.Web.ViewModels
{
    public class ProductsWidgetViewModels
    {
        public List<Product> Products { get; set; }
        public bool IsLatestProducts { get; set; }
    }
}