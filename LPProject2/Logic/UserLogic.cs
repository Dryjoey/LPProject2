using DAL;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;



namespace Logic
{
    public class UserLogic
    {
        public ICrud<User> user_dao { get; }

        public UserLogic()
        {
            user_dao = new UserDAO();
        }

        public void AddUser(User user)
        {
            user_dao.AddEntity(user);
        }

        public List<User> GetAllUsers()
        {
            return user_dao.GetObjects();
        }
    }
}
