using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Northwind.Entities.Concrete;

namespace AydinCompany.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable(@"Users", @"dbo");
            HasKey(x => x.UserId);

            Property(x => x.Email).HasColumnName("Email");
            Property(x => x.FirstName).HasColumnName("FirstName");
            Property(x => x.LastName).HasColumnName("LastName");
            Property(x => x.Password).HasColumnName("Password");
            Property(x => x.UserName).HasColumnName("UserName");
        }
    }
}
