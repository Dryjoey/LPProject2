using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class IGame
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public string category { get; private set; }
        public string description { get; private set; }
        public int price { get; private set; }
        public bool hireable { get; private set; }
    }
}
