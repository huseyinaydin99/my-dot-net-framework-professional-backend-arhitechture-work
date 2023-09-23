using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Core.Entities;

namespace AydinCompany.Core.DataAccess.EntityFramework
{
    //GetList gibi List dönderen bir metot çalıştırıldığında context kapanmadan çalıştırılabilmesi için gerekli olan repositorymiz. Bu daha performanslı çalışmasını sağlayacak çünkü context her seferinde kapanıp açılmayacak.
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private IDbSet<T> _entities;
        
        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table
        {
            get => this.Entities;
            set{}
        }

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }

                return _entities;
            }
        }
    }
}