using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LPProject2.Models
{
    public class LoginViewModel
    {
        
            [Required]
            public string Name { get; set; }

            [Required]
            
            public string Password { get; set; }
        
    }
}
