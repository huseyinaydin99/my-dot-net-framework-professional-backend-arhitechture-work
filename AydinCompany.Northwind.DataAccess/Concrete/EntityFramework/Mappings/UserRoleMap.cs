using AydinCompany.Northwind.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Northwind.Entities.Concrete;

namespace AydinCompany.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            ToTable(@"UserRoles", @"dbo");
            HasKey(x => x.UserId);

            Property(x => x.UserId).HasColumnName("UserId");
            Property(x => x.RoleId).HasColumnName("RoleId");
        }
    }
}
