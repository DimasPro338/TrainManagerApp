using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TrainManagerApp.Data;
using TrainManagerApp.Models;
using TrainManagerApp.ViewModels;

namespace TrainManagerApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataBaseContext dataBaseContext;

        public AccountController(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                User user = await dataBaseContext.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    if (user.RoleId == 2)
                    {
                        await Authenticate(user);
                        return RedirectToAction("AuthorizeUser", "UserTrain");
                    }
                    else
                    {
                        await Authenticate(user);
                        return RedirectToAction("AuthorizeUser", "AdminTrain");
                    }
                }                
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                User user = await dataBaseContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if(user == null)
                {
                    user = new User { Email = model.Email, Password = model.Password };
                    UserRole userRole = await dataBaseContext.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                        user.Role = userRole;

                    dataBaseContext.Users.Add(user);
                    await dataBaseContext.SaveChangesAsync();

                    await Authenticate(user);                                      
                    return RedirectToAction("AuthorizeUser", "AdminTrain");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
