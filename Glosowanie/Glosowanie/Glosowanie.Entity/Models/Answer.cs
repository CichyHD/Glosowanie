using Glosowanie.Entity.Models.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosowanie.Entity.Models
{
    public class Answer : BasicModel
    {
        public string AnswerText { get; set; }
        public int NumberOfChoses { get; set; }
    }
}
