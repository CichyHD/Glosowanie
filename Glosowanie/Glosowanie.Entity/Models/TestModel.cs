using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Glosowanie.Entity.Models.Interfaces;

namespace Glosowanie.Entity.Models
{
    public class TestModel:ITestModel
    {
        [Key,Required]
        public int Id { get; set; }
    }
}
