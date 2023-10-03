using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Northwind.DataAccess.Concrete.EntityFramework.Mappings;
using AydinCompany.Northwind.Entities.ComplexType;
using AydinCompany.Northwind.Entities.Concrete;
using UserRoleItem = AydinCompany.Northwind.Entities.ComplexType.UserRoleItem;

namespace AydinCompany.Northwind.DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext() : base(ConfigurationManager.ConnectionStrings["NorthwindContext"].ConnectionString)
        {
            Database.SetInitializer<NorthwindContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
