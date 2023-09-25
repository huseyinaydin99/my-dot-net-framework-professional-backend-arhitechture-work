using System;
//using System.Transactions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Core.Aspects.Postsharp;
using AydinCompany.Core.Aspects.Postsharp.TransactionAspects;
using AydinCompany.Core.Aspects.Postsharp.ValidationAspects;
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
        private readonly IQueryable<Product> _queryable;

        public ProductManager(IQueryable<Product> queryable, IProductDal productDal)
        {
            _queryable = queryable;
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

        [FluentValidationAspect(
            typeof(ProductValidator))] //aspect ile metot oncesine girilir. validasyon yapılır. validasyon gecerliyle metot çalışır görevini yerine getirir.
        public Product Update(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidator(), product); //her seferinde validasyon, caching, security, auditing, exception handling, transaction management... yapılırsa burası çorba olur. clean code'a, solid'e dry'a uymaz! delikanlı adama yakışmaz. o yüzden aspect'lerle metot öncesi ve sonrasına girilmelidir ihtiyaca göre.
            return _productDal.Update(product);
        }


        //Transaction yapılan DML işlemlerini sarmalar.
        //Burası kötü kod örneğidir. 
        //Böyle her metodun içine giripte Transaction Management yapılırsa ortalık 62 olur çorba olur temiz kod olmaz.
        //Böyle bir durum SOLID'e, DRY'a, Clean Code'a, OOP'e ve programcılığa yakışmaz.
        //Böyle kod yazan adam adam değildir :D şaka şaka.
        //Bu iş Aspect'lerle yapılmalıdır.
        /*public void TransactionalOperation(Product product, Product product2)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    _productDal.Add(product);
                    //business yani iş kodları bu noktada yer aldığını var sayalım.
                    _productDal.Add(product2);
                    //transactionScope.Complete();
                    //transactionScope.Commit();
                }
                catch (Exception e)
                {
                    //transactionScope.Dispose();
                    //transactionScope.Rollback();
                }
            }

        }*/
        [TransactionScopeAspect]
        public void TransactionalOperation(Product product, Product product2)
        {
            _productDal.Add(product);
            //business yani iş kodları bu noktada yer aldığını var sayalım.
            _productDal.Add(product2);
        }
    }
}