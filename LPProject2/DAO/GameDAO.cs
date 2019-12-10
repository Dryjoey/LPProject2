using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
   public  class GameDAO : DAO , ICrud<Game>
    {
        List<Game> Gamelist = new List<Game>();

        public List<Game> GetAllGames()
        {
            con.Open();

            string query = "SELECT * FROM GAMES";
            List<Game> result = new List<Game>();

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.ExecuteNonQuery();

                SqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                  result.Add(new Game(read.GetInt32(0), read.GetString(1), read.GetString(2),read.GetInt32(3), read.GetString(4), read.GetBoolean(5)));
                }
            }

            con.Close();

            return result;

        }


        public void UpdateEntity(int EntityId)
        {

        }

        public void DeleteEntity(int EntityId)
        {

        }

        public List<Game> GetObjects()
        {
            return null;
        }

        public void AddEntity(Game game)
        {
            con.Open();

            string query =

                "INSERT INTO Performer(Name, Category, Description, Hireable) VALUES (@Name, @Category, @Description, @Hireable)";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@Name", game.name);
                command.Parameters.AddWithValue("@Category", game.category);
                command.Parameters.AddWithValue("@Description", game.description);
                command.Parameters.AddWithValue("@Hireable", game.hireable);
                

                command.ExecuteNonQuery();

                con.Close();
            }
        }
        public void Hiregame(Game game, User user)
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
