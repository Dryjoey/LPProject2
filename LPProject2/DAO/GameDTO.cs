using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
namespace DAL
{
    class GameDTO: IGame
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public string category { get; private set; }
        public string description { get; private set; }
        public bool hireable { get; private set; }
    }
}
