using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntexMummy11.Models
{
    public class User
    {
        [Key]
        public string username { get; set; }
        public string password { get; set; }
    }
}
