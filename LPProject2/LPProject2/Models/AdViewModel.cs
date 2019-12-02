using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;

namespace LPProject2.Models
{
    public class AdViewModel: IAd
    {
        public int AdId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Game")]
        public IGame Game { get; set; }
         
    }
}
