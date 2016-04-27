using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Glosowanie.Models
{
    public class Token
    {
        public string TokenValue { get; set; }
        public bool Used { get; set; }
    }
}