using ObjectModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class Game
    {
        public Game(int id, string name, Categorie categorie, string description, bool hireable)
        {
            this.id = id;
            this.name = name;
            this.categorie = categorie;
            this.description = description;
            this.hireable = hireable;
        }

        public int id { get; private set; }
        public string name { get; private set; }
        public Categorie categorie { get; private set; }
        public string description { get; private set; }
        public bool hireable { get; private set; }
    }
}
