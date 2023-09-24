using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Core.DataAccess.EntityFramework;
using AydinCompany.Northwind.DataAccess.Abstract;
using AydinCompany.Northwind.Entities.ComplexType;

namespace AydinCompany.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
       
    }
}
