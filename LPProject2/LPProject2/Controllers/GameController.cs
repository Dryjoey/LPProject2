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

        public IActionResult AddGame(GameViewModel form_game)
        {
            GameLogic reader = new GameLogic();
            var game = new Game(0, form_game.GameName, form_game.Category, form_game.Discription, form_game.Hireable);
            reader.AddGame(game);
            return View("Game");
        }
    }
}