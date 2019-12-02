using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace DAL
{
    class AdDTO: IAd
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public IGame Game { get; private set; }
    }
}
