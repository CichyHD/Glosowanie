using Glosowanie.Entity.Models.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosowanie.Entity.Models
{
    public class Pool : BasicModel
    {
        public string Title { get; set; }
        public virtual IEnumerable<Question> Questions { get; set; }
        public virtual Token Tokens { get; set; }
    }
}
