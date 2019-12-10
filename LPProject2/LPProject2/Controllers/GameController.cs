using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using LPProject2.Models;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LPProject2.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GameForm()
        {
            return View("GameForm");
        }

        public IActionResult AddGame(GameViewModel form_game)
        {
            GameLogic reader = new GameLogic();
            var game = new Game(0, form_game.GameName, form_game.Category, form_game.price, form_game.Discription, form_game.Hireable);
            reader.AddGame(game);
            return View("Game");
        }
        [HttpGet]
        public IActionResult Overview()
        {
            GameLogic reader = new GameLogic();

            List<GameViewModel> resultAllGames = new List<GameViewModel>();
            

            foreach (var game in reader.GetAllGames())
            {
                resultAllGames.Add(new GameViewModel()
                {
                    GameId =  game.id,
                    GameName = game.name,
                    Category = game.category,
                    Price = game.price,
                    Discription = game.description,
                    Hireable = game.hireable


                });
                 
            }
            return View("Overview", resultAllGames);
        }
    }
}