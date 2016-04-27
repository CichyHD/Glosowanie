using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Glosowanie.Models
{
    public class Pool
    {
        [Required(ErrorMessage = "Pole wymagane")]
        public string Title { get; set; }

        public List<Question> Questions { get; set; }
    }
}