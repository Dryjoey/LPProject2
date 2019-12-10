using DAL;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class GameLogic
    {
        public ICrud<Game> game_dao { get; }
        public GameDAO gamedao { get; }

        public GameLogic()
        {
            game_dao = new GameDAO();
        }

        public void AddGame(Game game)
        {
            game_dao.AddEntity(game);
        }

        public List<Game> GetAllGames()
        {
            return game_dao.GetObjects();
        }

        public void HireGame(Game game, User user)
        {
            if(CheckifHired(game, user) == true)
            {
                gamedao.Hiregame(game, user);
            }
            else
            {
                new Exception("Cant hire twice");
            }
        }

        public bool CheckifHired(Game game, User user)
        {
            if (user.id == game.id)
            {
                return false;
            }
            return true;
        }
    }
}
