using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AydinCompany.Core.CrossCuttingConcerns.Security.Web;
using AydinCompany.Northwind.Business.Abstract;

namespace AydinCompany.Northwind.MVCWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public string Login(string userName, string password)
        {
            var user = _userService.GetByUserNameandPassword(userName, password);
            if (user != null)
            {
                AuthenticationHelper.CreateAuthCookie(
                    new Guid(),
                    user.UserName,
                    user.Email,
                    DateTime.Now.AddDays(15),
                    _userService.GetUserRoles(user).Select(u => u.RoleName).ToArray(),
                    false,
                    user.FirstName,
                    user.LastName);
                return "User is authenticated! Current User: " + "@huseyinaydin";
            }
            return "User is not authenticated!";
        }
    }
}