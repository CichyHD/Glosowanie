using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Glosowanie.Entity.Models;

namespace Glosowanie.DAL.Context
{
    public class GlosowanieContext : DbContext, IGlosowanieContext
    {
        public GlosowanieContext()
            : base("name=Glosowanie_ConnectionString")
        {
            Database.SetInitializer<GlosowanieContext>(new CreateDatabaseIfNotExists<GlosowanieContext>());
        }

        public DbSet<TestModel> TestModel { get; set; }
    }
}
