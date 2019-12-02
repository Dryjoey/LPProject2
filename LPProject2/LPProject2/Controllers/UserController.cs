using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using LPProject2.Models;
using Models;

namespace LPProject2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index(string id)
        {
            UserLogic reader = new UserLogic();

            List<UserViewModel> resultallusers = new List<UserViewModel>();

            foreach(var user in reader.GetAllUsers())
            {
                resultallusers.Add(new UserViewModel()
                {
                    Id = user.id,
                    Name = user.name,
                    Email = user.email,
                    Phone = user.tel,
                    Nationalty = user.nationality
                });
            }

            UserViewModel resultusers = new UserViewModel();

            resultusers = resultallusers.Find(x => x.Id == Int32.Parse(id));

            return View(resultallusers);
        }
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]

        public IActionResult AddUser(UserViewModel form_User)
        {
            UserLogic reader = new UserLogic();
            var user = new User(0, form_User.Name, form_User.Password,  form_User.Phone, form_User.Email, form_User.Nationalty);
            reader.AddUser(user);
            return View("Signup");
        }
        [HttpGet]
        public async Task<IActionResult> Overview()
        {
            UserLogic reader = new UserLogic();

            List<UserViewModel> resultAllUsers = new List<UserViewModel>();

            foreach (var user in reader.GetAllUsers())
            {
                resultAllUsers.Add(new UserViewModel()
                {
                    Id = user.id,
                    Name = user.name,
                    Phone = user.tel,
                    Email = user.email,
                    Nationalty = user.nationality


                }) ;
            }
            return View("Overview", resultAllUsers);
        }
    }
}