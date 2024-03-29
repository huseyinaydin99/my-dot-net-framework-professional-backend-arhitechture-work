﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AydinCompany.Northwind.Business.Abstract;
using AydinCompany.Northwind.Entities.ComplexType;

namespace AydinCompany.Northwind.MVCWebUI.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService _productService;

        public ProductsController()
        {

        }

        public ProductsController(IProductService productService)
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

        public string Add()
        {
            _productService.Add(new Product()
            {
                CategoryId = 1,
                ProductName = "GSM",
                QuantityPerUnit = "1",
                UnitPrice = 21
            });
            return "Eklendi";
        }

        public string AddUpdate()
        {
            _productService.TransactionalOperation(new Product()
                {
                    CategoryId = 1,
                    ProductName = "GSM",
                    QuantityPerUnit = "1",
                    UnitPrice = 21
                },
                new Product()
                {
                    CategoryId = 1,
                    ProductName = "GSM",
                    QuantityPerUnit = "1",
                    UnitPrice = -10
                });
            return "Bitti";
        }
    }
}