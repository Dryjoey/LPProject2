using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using DAL;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using LPProject2.Models;

namespace LPProject2.Controllers
{
    public class UserController : Controller
    {
        UserDAO ud = new UserDAO();
        SqlCommand com = new SqlCommand();
        SqlDataReader reader;
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
         
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
             
            if (!ModelState.IsValid) return View(model);


            UserDTO user = _repository.GetUserByName(model.Name);
            if (user == null)
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(model);
            }

             
            string hasher = BCrypt.Net.BCrypt.HashPassword(user.password);
            if (BCrypt.Net.BCrypt.Verify(model.Password, user.password))
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(model);
            }

            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.name)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Login");
        }

         
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    
    public IActionResult Index(string id)
        {
            User reader = new User();

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
            User reader = new User();
            BCrypt.Net.BCrypt.HashPassword(form_User.Password);
            var user = new global::DAL.UserDTO(0, form_User.Name, form_User.Password,  form_User.Phone, form_User.Email, form_User.Nationalty);
           
            reader.AddUser(user);
            return View("Signup");
        }
        [HttpGet]
        public IActionResult Overview()
        {
            User reader = new User();

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


                });
            }
            return View("Overview", resultAllUsers);
        }
        public string schijt = BCrypt.Net.BCrypt.HashPassword("henk123") ;

        [HttpGet]

         
        [HttpPost]
        public IActionResult Verify(global::Interfaces.IUser user)
        {
            ud.con.Open();
            com.Connection = ud.con;
            com.CommandText = "SELECT * from WebUser where Name='"+user.Name+"'and Password='"+user.Password+"'";
            reader = com.ExecuteReader();
            if (reader.Read())
            {
                ud.con.Close();
                return View();
            }
            else
            {
                ud.con.Close();
                return View();
                
            }
             
        }
    }
}