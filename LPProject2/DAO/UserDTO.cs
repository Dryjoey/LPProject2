using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public class UserDTO: IUser
    {
        public int id { get; set; }
        public string name { get;  set; }
        public string password { get;  set; }
        public string tel { get; private set; }
        public string email { get; private set; }
        public string nationality { get; private set; }
    }
}
