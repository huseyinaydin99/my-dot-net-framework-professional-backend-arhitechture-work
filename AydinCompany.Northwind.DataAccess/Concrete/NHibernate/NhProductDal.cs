using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Core.DataAccess.NHibernate;
using AydinCompany.Northwind.DataAccess.Abstract;
using AydinCompany.Northwind.Entities.ComplexType;

namespace AydinCompany.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhProductDal : NhEntityRepositoryBase<Product>, IProductDal
    {
        public NhProductDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {

        }
    }
}
