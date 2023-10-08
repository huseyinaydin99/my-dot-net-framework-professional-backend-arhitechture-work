using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AydinCompany.Northwind.Business.Abstract;
using AydinCompany.Northwind.Business.DependencyResolvers.Ninject;
using AydinCompany.Northwind.Business.ServiceContracts.WCF;
using AydinCompany.Northwind.Entities.ComplexType;

/// <summary>
/// Summary description for ProductDetailService
/// </summary>
public class ProductDetailService : IProductDetailService
{
    public ProductDetailService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private IProductService _productService = InstanceFactory.GetInstance<IProductService>();
    public List<Product> GetAll()
    {
        return _productService.GetAll();
    }
}