using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Northwind.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;
using FluentNHibernate.Mapping;
using FluentNHibernate.Testing.Values;
using AydinCompany.Northwind.Entities.ComplexType;
using FluentNHibernate.Conventions.Helpers;

namespace AydinCompany.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable(@"Categories", @"dbo");
            HasKey(x => x.CategoryId);

            Property(x => x.CategoryId).HasColumnName("CategoryID");
            Property(x => x.CategoryName).HasColumnName("CategoryName");
        }
    }
}
