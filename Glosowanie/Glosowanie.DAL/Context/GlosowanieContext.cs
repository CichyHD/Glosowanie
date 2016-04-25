using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Glosowanie.Entity.Models;
using Glosowanie.Entity.Models.Basic;
using System.Threading;

namespace Glosowanie.DAL.Context
{
    public class GlosowanieContext : DbContext, IGlosowanieContext
    {
        public GlosowanieContext()
            : base("name=Glosowanie_ConnectionString")
        {
            Database.SetInitializer<GlosowanieContext>(new CreateDatabaseIfNotExists<GlosowanieContext>());
        }

        public DbSet<Pool> Questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IBasicModel
                    && (x.State == System.Data.Entity.EntityState.Added
                        || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IBasicModel entity = entry.Entity as IBasicModel;
                if (entity != null)
                {
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }
    }
}
