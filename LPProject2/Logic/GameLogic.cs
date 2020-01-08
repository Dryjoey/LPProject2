using DAL;
using Interfaces;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class Game : IGame
    {
         
             
        
        public ICrud<GameDTO> game_dao { get; }
        public GameDAO gamedao { get; }
        public void convert(GameDTO game)
        {
            game.Id = id;
            game.Name = name;
            game.Description = description;
            game.Category = category;
            game.Price = price;
            game.Hireable = hireable;
        }

        public Game()
        {
            GameDAO gamedao = new GameDAO();
        }

        public void AddGame(GameDTO game)
        {
            game_dao.AddEntity(game);
        }

        public List<GameDTO> GetAllGames()
        {
            return game_dao.GetObjects();
        }

        public void HireGame(GameDTO game)
        {
            convert(game);
            
            if(CheckifHired(game) == true)
            {
                 
            }
            else
            {
                new Exception("Cant hire twice");
            }
        }

        public bool CheckifHired(GameDTO game)
        {
            return true;
        }
    }
}
