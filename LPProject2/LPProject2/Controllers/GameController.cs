using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Logic;
using LPProject2.Models;
using Microsoft.AspNetCore.Mvc;
 

namespace LPProject2.Controllers
{
    public class GamesController : Controller
    {
        

        public IActionResult GameForm()
        {
            return View();
        }

        public IActionResult AddGame(GameViewModel form_game)
        {

            Game reader = new Game();
           
            var game = new GameDTO(0, form_game.Name, form_game.Category, form_game.Price, form_game.Discription, form_game.Hireable);
            
            reader.AddGame(game);
            return View("Games");
        }
        [HttpGet]
        public IActionResult Games()
        {
            Game reader = new Game();

            List<GameViewModel> resultAllGames = new List<GameViewModel>();
            

            foreach (var game in reader.GetAllGames())
            {
                resultAllGames.Add(new GameViewModel()
                {
                    GameId =  game.Id,
                    Name = game.Name,
                    Category = game.Category,
                    Price = game.Price,
                    Discription = game.Description,
                    Hireable = game.Hireable


                });
                 
            }
            return View("Games", resultAllGames);
        }
    }
}