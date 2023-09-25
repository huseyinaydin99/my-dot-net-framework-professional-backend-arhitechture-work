using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Northwind.Business.Abstract;
using AydinCompany.Northwind.Business.Concrete.Manager;
using AydinCompany.Northwind.DataAccess.Abstract;
using AydinCompany.Northwind.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;

namespace AydinCompany.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope(); //IProductService istediğimizde bize otomatik olarak ProductManager verecek. ProductManager aslında IProductService interface'isini implemente ettiği için IProductService interface'si kendisini implemente eden sınıfın bellek referansını tutabiliyor. Dolayısıyla switch edilebilir bir yapı oluşuyor. Esnek bağlar(loose couplings) kurulabiliyor. Bu da sürdürülebilir yazılım projesi demektir. 
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
        }
    }
}
