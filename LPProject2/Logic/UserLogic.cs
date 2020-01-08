using DAL;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
 



namespace Logic
{
    public class User : IUser
    {
      
        public ICrud<UserDTO> user_dao { get; }

        public User()
        {
            UserDAO user_dao = new UserDAO();
        }

        public void AddUser(UserDTO user)
        {
            user_dao.AddEntity(user);
        }

        public List<UserDTO> GetAllUsers()
        {
            return user_dao.GetObjects();
        }
    }
}
