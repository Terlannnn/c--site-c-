using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using sayt3.Models;
using Microsoft.AspNetCore.Authorization;

namespace sayt3.Controllers
{
    public class LoginController : Controller
    {
        KitablarContext db = new KitablarContext();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = db.Users.Include(x => x.UserStatus).SingleOrDefault(x => x.UserLogin == username && x.UserPassword == password);

            if (user != null)
            {

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.UserAd),
                    new Claim(ClaimTypes.Surname, user.UserSoyad),
                    new Claim(ClaimTypes.Role, user.UserStatus.StatussAd),
                    new Claim(ClaimTypes.Sid, user.UserId.ToString())
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principial = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principial, props).Wait();
                //User.FindFirst(ClaimTypes.Sid).Value;
                if (user.UserStatus.StatussAd == "admin")
                {
                    return RedirectToAction("Kitab", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");

                }
            }
            return View();
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync().Wait();

            return RedirectToAction("login", "Login");
        }
    }

}


