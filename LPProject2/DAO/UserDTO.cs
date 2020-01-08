using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public class UserDTO
    {
        public UserDTO(int id, string name, string password, int tel, string email, string nationality)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.tel = tel;
            this.email = email;
            this.nationality = nationality;

        }

        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public int tel { get; set; }
        public string email { get; set; }
        public string nationality { get; set; }

    }
}
