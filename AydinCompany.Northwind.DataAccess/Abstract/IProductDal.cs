using AydinCompany.Core.DataAccess;
using AydinCompany.Northwind.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AydinCompany.Northwind.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {

    }
}
