using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace AydinCompany.Core.DataAccess.NHibernate
{
    public abstract class NHibernateHelper : IDisposable
    {
        private static ISessionFactory _sessionFactory;

        public virtual ISessionFactory SessionFactory //virtual vermemizin sebebi lazy loading(ilişki tablolardaki verilerinde yüklenmesi) içindir. 
        {
            get { return _sessionFactory ?? (_sessionFactory = InitializeFactory()); }
        }

        protected abstract ISessionFactory InitializeFactory();

        public virtual ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
