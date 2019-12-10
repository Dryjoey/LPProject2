using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using LPProject2.Models;
using Models;
using DAL;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

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

             
            var hasher = new PasswordHasher<UserDTO>();
            if (hasher.VerifyHashedPassword(user, user.password, model.Password) == PasswordVerificationResult.Failed)
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

            return LocalRedirect(returnUrl);
        }

         
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    
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
        public IActionResult Overview()
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


                });
            }
            return View("Overview", resultAllUsers);
        }

        [HttpGet]

         
        [HttpPost]
        public IActionResult Verify(User user)
        {
            ud.con.Open();
            com.Connection = ud.con;
            com.CommandText = "SELECT * from WebUser where Email='"+user.email+"'and Password='"+user.password+"'";
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