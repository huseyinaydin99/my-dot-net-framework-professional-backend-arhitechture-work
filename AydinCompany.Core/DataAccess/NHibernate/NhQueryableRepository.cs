using System.Linq;
using AydinCompany.Core.Entities;
using NHibernate.Linq;

namespace AydinCompany.Core.DataAccess.NHibernate
{
    //GetList gibi List dönderen bir metot çalıştırıldığında context kapanmadan çalıştırılabilmesi için gerekli olan repositorymiz. Bu daha performanslı çalışmasını sağlayacak çünkü context her seferinde kapanıp açılmayacak.
    public class NhQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private NHibernateHelper _hibernateHelper;
        private IQueryable<T> _entities;

        public NhQueryableRepository(NHibernateHelper hibernateHelper)
        {
            _hibernateHelper = hibernateHelper;
        }

        public IQueryable<T> Table
        {
            get { return this.Entities; }
            set{}
        }

        public virtual IQueryable<T> Entities
        {
            get { return _entities ?? (_entities = _hibernateHelper.OpenSession().Query<T>()); }
        }
    }
}