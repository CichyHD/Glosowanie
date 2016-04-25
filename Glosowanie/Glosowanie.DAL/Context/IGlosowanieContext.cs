using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glosowanie.Entity.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Glosowanie.DAL.Context
{
    public interface IGlosowanieContext:IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        DbEntityEntry Entry(object entity);
    }
}
