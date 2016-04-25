using Glosowanie.Entity.Models.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosowanie.DAL.Repositories.Generic
{
    public interface IGenericRepository<T> where T : BasicModel
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
