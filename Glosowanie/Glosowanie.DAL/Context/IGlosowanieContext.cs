using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glosowanie.Entity.Models;
using System.Data.Entity;

namespace Glosowanie.DAL.Context
{
    public interface IGlosowanieContext:IDisposable
    {
        DbSet<TestModel> TestModel { get; set; }
    }
}
