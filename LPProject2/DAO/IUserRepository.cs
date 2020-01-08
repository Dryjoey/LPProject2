 
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUserRepository
    {
        UserDTO GetUserByName(string username);
    }
}
