using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Northwind.Entities.ComplexType;
using FluentNHibernate.Mapping;

namespace AydinCompany.Northwind.DataAccess.Concrete.NHibernate.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table(@"Products");
            LazyLoad();

            Id(x => x.ProductId).Column("ProductID");

            Map(x => x.CategoryId).Column("CategoryID");
            Map(x => x.ProductName).Column("ProductName");
            Map(x => x.QuantityPerUnit).Column("QuantityPerUnit");
            Map(x => x.UnitPrice).Column("UnitPrice");
        }
    }
}
