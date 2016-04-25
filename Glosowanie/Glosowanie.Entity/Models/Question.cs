using Glosowanie.Entity.Models.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosowanie.Entity.Models
{
    public class Question : BasicModel
    {
        public string QuestionText { get; set; }
        public virtual Answer Answers { get; set; }
    }
}
