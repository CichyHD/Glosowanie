using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Glosowanie.Models
{
    public class Token
    {
        public string TokenValue { get; set; }

        public int NumberOfQuestions { get; set; }
        public int NumberOfAnswers { get; set; }
    }
}