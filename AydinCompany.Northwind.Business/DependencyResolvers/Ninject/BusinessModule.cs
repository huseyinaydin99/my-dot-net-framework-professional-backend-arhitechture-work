using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Core.DataAccess;
using AydinCompany.Core.DataAccess.EntityFramework;
using AydinCompany.Core.DataAccess.NHibernate;
using AydinCompany.Northwind.Business.Abstract;
using AydinCompany.Northwind.Business.Concrete.Manager;
using AydinCompany.Northwind.DataAccess.Abstract;
using AydinCompany.Northwind.DataAccess.Concrete.EntityFramework;
using AydinCompany.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using Ninject.Modules;

namespace AydinCompany.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            Bind<IProductService>().To<ProductManager>().InSingletonScope(); //IProductService istediğimizde bize otomatik olarak ProductManager verecek. ProductManager aslında IProductService interface'isini implemente ettiği için IProductService interface'si kendisini implemente eden sınıfın bellek referansını tutabiliyor. Dolayısıyla switch edilebilir bir yapı oluşuyor. Esnek bağlar(loose couplings) kurulabiliyor. Bu da sürdürülebilir yazılım projesi demektir. 
            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));

            Bind<IUserService>().To<UserManager>();
            Bind<IUserDal>().To<EfUserDal>();

            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
