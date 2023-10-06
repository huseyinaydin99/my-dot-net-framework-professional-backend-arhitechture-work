using System;
//using System.Transactions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AydinCompany.Core.Aspects.Postsharp;
using AydinCompany.Core.Aspects.Postsharp.AuthorizationAspects;
using AydinCompany.Core.Aspects.Postsharp.CacheAspects;
using AydinCompany.Core.Aspects.Postsharp.LogAspects;
using AydinCompany.Core.Aspects.Postsharp.TransactionAspects;
using AydinCompany.Core.Aspects.Postsharp.ValidationAspects;
using AydinCompany.Core.CrossCuttingConcerns.Caching.Microsoft;
using AydinCompany.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using AydinCompany.Core.Utilities.Mappings;
using AydinCompany.Northwind.Business.Abstract;
using AydinCompany.Northwind.Business.ValidationRules.FluentValidation;
using AydinCompany.Northwind.DataAccess.Abstract;
using AydinCompany.Northwind.Entities.ComplexType;

namespace AydinCompany.Northwind.Business.Concrete.Manager
{
    //[LogAspect(typeof(FileLogger))] //tüm metotlar loglanır.
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        private IMapper _mapper;
        //private readonly IQueryable<Product> _queryable;

        public ProductManager(/*IQueryable<Product> queryable,*/ IProductDal productDal, IMapper mapper)
        {
            //_queryable = queryable;
            _productDal = productDal;
            _mapper = mapper;
        }


        [CacheAspect(typeof(MemoryCacheManager), 59)]
        //[LogAspect(typeof(DatabaseLogger))] //database DatabaseLogger ile loglayacağım dedik.
        //aynı zamanda FileLogger ile loglayacaksın dedik.
        //[SecuredOperation(Roles = "Admin, Editor")]
        [SecuredOperation(Roles = "Admin")]
        public List<Product> GetAll()
        {
            Thread.Sleep(3800);
            /*return _productDal.GetList().Select(p => new Product()
            {
                CategoryId = p.CategoryId,
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                QuantityPerUnit = p.QuantityPerUnit,
                UnitPrice = p.UnitPrice,
            }).ToList();*/
            //var products = AutoMapperHelper.MapToSameTypeList(_productDal.GetList());
            var products = _mapper.Map<List<Product>>(_productDal.GetList());
            return products;
        }
        
        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidator(), product); //her seferinde validasyon, caching, security, auditing, exception handling, transaction management... yapılırsa burası çorba olur. clean code'a, solid'e dry'a uymaz! delikanlı adama yakışmaz. o yüzden aspect'lerle metot öncesi ve sonrasına girilmelidir ihtiyaca göre.
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidator))] //aspect ile metot oncesine girilir. validasyon yapılır. validasyon gecerliyle metot çalışır görevini yerine getirir.
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
        [FluentValidationAspect(typeof(ProductValidator))]
        public void TransactionalOperation(Product product, Product product2)
        {
            _productDal.Add(product);
            //business yani iş kodları bu noktada yer aldığını var sayalım.
            _productDal.Add(product2);
        }
    }
}