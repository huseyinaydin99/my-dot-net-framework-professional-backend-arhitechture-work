using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Northwind.DataAccess.Concrete.EntityFramework.Mappings;
using AydinCompany.Northwind.Entities.ComplexType;

namespace AydinCompany.Northwind.DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
            Database.SetInitializer<NorthwindContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
        }

        public DbSet<Product> Products { get; set; }
    }
}
