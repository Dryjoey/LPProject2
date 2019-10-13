using System;

namespace Models
{
    public class User
    {
        public User(int id, string name, string password, string tel, string email, string nationality, bool admin)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.tel = tel;
            this.email = email;
            this.nationality = nationality;
            this.admin = admin;
        }

        public int id { get; private set; }
        public string name { get; private set; }
        public string password { get; private set; }
        public string tel { get; private set; }
        public string email { get; private set; }
        public string nationality { get; private set; }
        public bool admin { get; private set; }
        

        
    }
}
