using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Core.Aspects.Postsharp;
using AydinCompany.Core.CrossCuttingConserns.Validation.FluentValidation;
using AydinCompany.Northwind.Business.Abstract;
using AydinCompany.Northwind.Business.ValidationRules.FluentValidation;
using AydinCompany.Northwind.DataAccess.Abstract;
using AydinCompany.Northwind.Entities.ComplexType;

namespace AydinCompany.Northwind.Business.Concrete.Manager
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Add(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidator(), product); //her seferinde validasyon, caching, security, auditing, exception handling, transaction management... yapılırsa burası çorba olur. clean code'a, solid'e dry'a uymaz! delikanlı adama yakışmaz. o yüzden aspect'lerle metot öncesi ve sonrasına girilmelidir ihtiyaca göre.
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidator))]//aspect ile metot oncesine girilir. validasyon yapılır. validasyon gecerliyle metot çalışır görevini yerine getirir.
        public Product Update(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidator(), product); //her seferinde validasyon, caching, security, auditing, exception handling, transaction management... yapılırsa burası çorba olur. clean code'a, solid'e dry'a uymaz! delikanlı adama yakışmaz. o yüzden aspect'lerle metot öncesi ve sonrasına girilmelidir ihtiyaca göre.
            return _productDal.Update(product);
        }
    }
}
