using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public class GameDTO
    {
         
            public GameDTO(int id, string name, string categorie, string price, string description, bool hireable)
            {
                this.Id = id;
                this.Name = name;
                this.Category = categorie;
                this.Price = price;
                this.Description = description;
                this.Hireable = hireable;
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public string Price { get; set; }
            public string Description { get; set; }
            public bool Hireable { get; set; }
        
    }
}
