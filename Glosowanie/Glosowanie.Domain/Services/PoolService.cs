using Glosowanie.DAL.Repositories;
using Glosowanie.DAL.UnitOfWorkk;
using Glosowanie.Domain.Services.Generic;
using Glosowanie.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosowanie.Domain.Services
{
    public class PoolService : GenericService<Pool>, IPoolService
    {
        readonly IPoolRepository _poolRepository;

        public PoolService(IUnitOfWork unitOfWork, IPoolRepository _poolRepository)
            : base(unitOfWork, _poolRepository)
        {
            this._poolRepository = _poolRepository;
        }
    }
}
