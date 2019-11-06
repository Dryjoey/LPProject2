using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace DAL
{
    public class UserDAO : DAO, ICrud<User>
    {
        List<User> user = new List<User>();
       
        public List<User> GetAllPerformers()
        {
            con.Open();

            string query = "SELECT * FROM User";
            List<User> result = new List<User>();

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.ExecuteNonQuery();

                SqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    result.Add(new User(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetString(3), read.GetString(4),
                        read.GetString(5)));
                }

                con.Close();

                return result;
            }
        }
        public void AddEntity(User user)
        {
            con.Open();

            string query =

                "INSERT INTO User(Id, Name, Password, Email, Tel, Nationalty, Admin) VALUES (@Id, @Name, @Password, @Email, @Tel, @Nationalty)";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@Id", user.id);
                command.Parameters.AddWithValue("@Name", user.name);
                command.Parameters.AddWithValue("@Password", user.password);
                command.Parameters.AddWithValue("@Email", user.email);
                command.Parameters.AddWithValue("@Tel", user.tel);
                command.Parameters.AddWithValue("@Nationalty", user.nationality);
              
                


                command.ExecuteNonQuery();

                con.Close();
            }
        }

        public List<User> GetObjects()
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(int EntityId)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(int EntityId)
        {
            throw new NotImplementedException();
        }
    }
}

