using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetSwaggerVictorLimao.Models
{
    public class User
    {
        public int Id{ get; set; }
        [Required]
        public string Name{ get; set; }
        [Required]
        public string CPF{ get; set; }
        [Required]
        public string Gender{ get; set; }
    }
}
