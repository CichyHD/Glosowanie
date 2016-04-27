using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosowanie.Entity.Models.Basic
{
    public interface IBasicModel
    {
        DateTime CreatedDate { get; set; }
        int Id { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
