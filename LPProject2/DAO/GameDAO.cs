using Interfaces;
 
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
   public  class GameDAO : DAO , ICrud<GameDTO>
    {
        List<GameDTO> Gamelist = new List<GameDTO>();

        public List<GameDTO> GetAllGames()
        {
            return null;
        }


        public void UpdateEntity(int EntityId)
        {

        }

        public void DeleteEntity(int EntityId)
        {

        }

        public List<GameDTO> GetObjects()
        {
                con.Open();

            string query = @"SELECT GameId, Name, Category, Description, Price, Hireable FROM GAME";

            List<GameDTO> result = new List<GameDTO>();

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.ExecuteNonQuery();

                    SqlDataReader read = command.ExecuteReader();

                    while (read.Read())
                    {
                        result.Add(new GameDTO(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetString(3), read.GetString(4), read.GetBoolean(5)));
                    }
                }

                con.Close();

                return result;

            
        }

        public void AddEntity(GameDTO game)
        {
            con.Open();

            string query =

                "INSERT INTO GAME(GameId, Name, Category, Description, Price, Hireable) VALUES (@GameId, @Name, @Category, @Description, @Price, @Hireable)";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@GameId", game.Id);
                command.Parameters.AddWithValue("@Name", game.Name);
                command.Parameters.AddWithValue("@Category", game.Category);
                command.Parameters.AddWithValue("@Description", game.Description);
                command.Parameters.AddWithValue("@Price", game.Price);
                command.Parameters.AddWithValue("@Hireable", game.Hireable);
                

                command.ExecuteNonQuery();

                con.Close();
            }
        }
        public void Hiregame(GameDTO game, UserDTO user)
        {
            con.Open();
            string query = "SELECT Game.GameID, WebUser.WebUser.Name FROM Game INNER JOIN WebUser ON Game.GameID = WebUser.WebuserID";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                
                command.ExecuteNonQuery();
            }
            con.Close();
        }
    }
}
