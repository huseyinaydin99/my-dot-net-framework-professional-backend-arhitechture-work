using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Core.DataAccess.EntityFramework;
using AydinCompany.Northwind.DataAccess.Abstract;
using AydinCompany.Northwind.Entities.ComplexType;
using AydinCompany.Northwind.Entities.Concrete;

namespace AydinCompany.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<UserRoleItem> GetUserRoles(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from ur in context.UserRoles
                    join r in context.Roles
                        on ur.UserRoleId equals user.UserId
                    where ur.UserId == user.UserId
                    select new UserRoleItem()
                    {
                        RoleName = r.Name
                    };
                return result.ToList();
            }
        }
    }
}
