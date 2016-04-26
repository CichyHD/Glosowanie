using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Glosowanie.Models
{
    public class Question
    {
        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; }
    }
}