using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    class UserDTO: IUser
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public string password { get; private set; }
        public string tel { get; private set; }
        public string email { get; private set; }
        public string nationality { get; private set; }
    }
}
