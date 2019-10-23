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
    }
}
