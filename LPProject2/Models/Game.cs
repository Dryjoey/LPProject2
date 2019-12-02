using ObjectModels;
using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;


namespace Models
{
   public class Game :IGame
    {
        public Game(int id, string name, string categorie, string description, bool hireable)
        {
            this.id = id;
            this.name = name;
            this.category = categorie;
            this.description = description;
            this.hireable = hireable;
        }

        public int id { get; private set; }
        public string name { get; private set; }
        public string category { get; private set; }
        public string description { get; private set; }
        public bool hireable { get; private set; }
    }
}
