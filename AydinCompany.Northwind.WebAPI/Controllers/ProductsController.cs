using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AydinCompany.Northwind.Business.Abstract;
using AydinCompany.Northwind.Entities.ComplexType;

namespace AydinCompany.Northwind.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductService _productService;

        /*public ProductsController()
        {

        }*/

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> Get()
        {
            return _productService.GetAll();
        }
    }
}
