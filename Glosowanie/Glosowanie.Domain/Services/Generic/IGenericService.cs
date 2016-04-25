using Glosowanie.Entity.Models.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosowanie.Domain.Services.Generic
{
    public interface IGenericService<T>
     where T : BasicModel
    {
        void Create(T entity);
        void Delete(T entity);
        System.Collections.Generic.IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
