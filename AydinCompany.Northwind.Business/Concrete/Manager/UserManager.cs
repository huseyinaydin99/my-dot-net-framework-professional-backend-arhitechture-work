using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Northwind.Business.Abstract;
using AydinCompany.Northwind.DataAccess.Abstract;
using AydinCompany.Northwind.Entities.ComplexType;
using AydinCompany.Northwind.Entities.Concrete;

namespace AydinCompany.Northwind.Business.Concrete.Manager
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetByUserNameandPassword(string userName, string password)
        {
            return _userDal.Get(u => u.UserName == userName && u.Password == password);
        }

        public List<UserRoleItem> GetUserRoles(User user)
        {
            return _userDal.GetUserRoles(user);
        }
    }
}
