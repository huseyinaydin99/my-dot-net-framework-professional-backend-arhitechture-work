using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AydinCompany.Northwind.Business.Abstract;

namespace AydinCompany.Northwind.MVCWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController()
        {
            
        }

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new ProductListViewModel()
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }
    }
}