using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Core.Entities;

namespace AydinCompany.Core.DataAccess
{
    //GetList gibi List dönderen bir metot çalıştırıldığında context kapanmadan çalıştırılabilmesi için gerekli olan repositorymiz. Bu daha performanslı. 
    public interface IQueryableRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> Table { get; set; }
    }
}
