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
                    UserId = user.id,
                    UserName = user.name,
                    UserEmail = user.email,
                    UserPhone = user.tel,
                    UserNationalty = user.nationality
                });
            }

            UserViewModel resultusers = new UserViewModel();

            resultusers = resultallusers.Find(x => x.UserId == Int32.Parse(id));

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
            var user = new User(0, form_User.UserName, form_User.Password, form_User.UserEmail, form_User.UserPhone, form_User.UserNationalty);
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
                    UserId = user.id,
                    UserName = user.name,
                    UserPhone = user.tel,
                    UserEmail = user.email,
                    UserNationalty = user.nationality


                }) ;
            }
            return View("Overview", resultAllUsers);
        }
    }
}