using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Northwind.Entities.ComplexType;

namespace AydinCompany.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable(@"Products", @"dbo");
            HasKey(x => x.ProductId);

            Property(x => x.ProductId).HasColumnName("ProductID");
            Property(x => x.CategoryId).HasColumnName("CategoryID");
            Property(x => x.ProductName).HasColumnName("ProductName");
            Property(x => x.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            Property(x => x.UnitPrice).HasColumnName("UnitPrice");

        }
    }
}
