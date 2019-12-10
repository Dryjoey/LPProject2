using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;

namespace LPProject2.Models
{
    public class GameViewModel: IGame
    {
        public int GameId { get; set; }
        [Display(Name = "Name")]
        public string GameName { get; set; }
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Display(Name ="Price")]
        public int Price { get; set; }
        [Display(Name = "Discription")]
        public string Discription { get; set; }
        [Display(Name = "Hireable")]
        public bool Hireable { get; set; }
    }
}
