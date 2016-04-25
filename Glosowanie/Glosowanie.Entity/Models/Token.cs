using Glosowanie.Entity.Models.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosowanie.Entity.Models
{
    public class Token : BasicModel
    {
        public string TokenValue { get; set; }
        public bool Used { get; set; }
    }
}
