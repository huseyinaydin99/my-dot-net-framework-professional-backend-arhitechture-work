using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Core.DataAccess;
using AydinCompany.Northwind.DataAccess.Concrete.EntityFramework;
using AydinCompany.Northwind.Entities.ComplexType;
using AydinCompany.Northwind.Entities.Concrete;

namespace AydinCompany.Northwind.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<UserRoleItem> GetUserRoles(User user);
    }
}
