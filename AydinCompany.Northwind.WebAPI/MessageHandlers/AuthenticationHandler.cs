using System;
using System.Linq;
using System.Management.Instrumentation;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using AydinCompany.Northwind.Business.Abstract;
using AydinCompany.Northwind.Business.DependencyResolvers.Ninject;
using AydinCompany.Northwind.Entities.Concrete;

namespace AydinCompany.Northwind.WebAPI.MessageHandlers
{
    public class AuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = request.Headers.GetValues("Authorization").FirstOrDefault();
                if (token != null)
                {
                    byte[] data = Convert.FromBase64String(token);
                    string decodedString = Encoding.UTF8.GetString(data);
                    string[] tokenValues = decodedString.Split(':');
                    IUserService userService = InstanceFactory.GetInstance<IUserService>();
                    User user = userService.GetByUserNameandPassword(tokenValues[0], tokenValues[1]);
                    //if (tokenValues[0] == "engin" && tokenValues[1] == "12345")
                    if (user != null)
                    {
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(tokenValues[0]), userService.GetUserRoles(user).Select(u => u.RoleName).ToArray());
                        Thread.CurrentPrincipal = principal; //Backend tarafı için Identity. Yani kullanıcının set edilmesi.
                        HttpContext.Current.User = principal; //WebAPI'de Authorization'u rolleriyle birlikte kullanabiliriz.
                    }
                }
            }
            catch
            {
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}