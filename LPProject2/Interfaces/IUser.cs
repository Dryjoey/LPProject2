using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class IUser
    {
        public IUser()
        {
        }

        public IUser(int id, string name, string password, int tel, string email, string nationality)
        {
            Id = id;
            Name = name;
            Password = password;
            Tel = tel;
            Email = email;
            Nationality = nationality;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }
        public int Tel { get; private set; }
        public string Email { get; private set; }
        public string Nationality { get; private set; }
    }
}
