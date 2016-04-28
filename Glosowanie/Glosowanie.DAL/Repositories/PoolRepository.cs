using Glosowanie.DAL.Context;
using Glosowanie.DAL.Repositories.Generic;
using Glosowanie.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosowanie.DAL.Repositories
{
    public class PoolRepository : GenericRepository<Pool>, IPoolRepository
    {
        public PoolRepository(IGlosowanieContext _context)
            : base(_context)
        {

        }
    }
}
