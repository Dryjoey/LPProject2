using Interfaces;
 
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace DAL
{
    public class UserDAO : DAO, ICrud<UserDTO>, IUserRepository
    {
        List<UserDTO> user = new List<UserDTO>();
       
        public List<UserDTO> GetAllPerformers()
        {
            con.Open();

            string query = "SELECT * FROM WebUser";
            List<UserDTO> result = new List<UserDTO>();

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.ExecuteNonQuery();

                SqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    result.Add(new UserDTO(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetInt32(3), read.GetString(4),
                        read.GetString(5)));
                }

                con.Close();

                return result;
            }
        }
        public void AddEntity(UserDTO user)
        {
            con.Open();

            string query =

                "INSERT INTO [WebUser] (idUser, Name, Password, Email, Tel, Nationalty) VALUES (@idUser, @Name, @Password, @Email, @Tel, @Nationalty)";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@idUser", user.id);
                command.Parameters.AddWithValue("@Name", user.name);
                command.Parameters.AddWithValue("@Password", user.password);
                command.Parameters.AddWithValue("@Email", user.email);
                command.Parameters.AddWithValue("@Tel", user.tel);
                command.Parameters.AddWithValue("@Nationalty", user.nationality);
              
                


                command.ExecuteNonQuery();

                con.Close();
            }
        }

        public List<UserDTO> GetObjects()
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

        public UserDTO GetUserByName(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));

            con.Open();

            var cmd = new SqlCommand("SELECT [idUser], [Name], [Password], [Email], [Tel], [Nationalty] FROM [WebUser] WHERE [Name] = @Name", con);
            cmd.Parameters.Add(new SqlParameter("Name", username));

            var reader = cmd.ExecuteReader();

            UserDTO user = null;

            while (reader.Read())
            {
                int userid = (int)reader["idUser"];
                int tel = Convert.ToInt32(reader["Tel"]);
                user = new UserDTO(id: userid , name: reader["Name"].ToString(), password: reader["Password"].ToString(),  email: reader["Email"].ToString(), tel:tel, nationality: reader["Nationalty"].ToString());
                 
            }

            return user;
        }
    }
}

