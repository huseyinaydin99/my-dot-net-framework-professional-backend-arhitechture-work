using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Northwind.Entities.ComplexType;
using AydinCompany.Northwind.Entities.Concrete;

namespace AydinCompany.Northwind.Business.Abstract
{
    public interface IUserService
    {
        User GetByUserNameandPassword(string userName, string password);
        List<UserRoleItem> GetUserRoles(User user);
    }
}
