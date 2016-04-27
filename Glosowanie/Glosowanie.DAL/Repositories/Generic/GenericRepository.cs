using Glosowanie.DAL.Context;
using Glosowanie.Entity.Models.Basic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosowanie.DAL.Repositories.Generic
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BasicModel
    {
        protected IGlosowanieContext _entities;
        protected readonly IDbSet<T> _dbset;

        public GenericRepository(IGlosowanieContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable<T>();
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicete)
        {
            IEnumerable<T> query = _dbset.Where(predicete).AsEnumerable();
            return query;
        }

        public virtual T Add(T entity)
        {
            return _dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return _dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
