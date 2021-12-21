using G2G1FinalProject.Data;
using G2G1FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace G2G1FinalProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _db;

        public AccountController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserId,FullName,UserName,Password,Email,isLocked,isAdmin")] User user)
        {
            if (ModelState.IsValid)
            {
                _db.Add(user);
                await _db.SaveChangesAsync();
                return RedirectToAction("Login", "Account");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (user.UserName == "null" || user.Password == "null")
            {
                ViewBag.Error = "Username And Password Cannot Be Empty";
            }
            else
            {
                var chkLogin = _db.Users.Where(m => m.UserName.Equals(user.UserName) && m.Password.Equals(user.Password));
                if (chkLogin.Any())
                {
                    if (chkLogin.FirstOrDefault().isLocked == true)
                    {
                        return RedirectToAction("AccountLocked");
                    }
                    else
                    {
                        HttpContext.Session.SetString("uName", user.UserName);
                        if (chkLogin.FirstOrDefault().isAdmin == true)
                        {
                            return RedirectToAction("Index", "Home", new { Area = "Admin" });
                        }
                        else if (chkLogin.FirstOrDefault().isAdmin == false)
                        {
                            return RedirectToAction("Index", "Home", new { Area = "Client" });
                        }
                    }
                }
                else
                {
                    ViewBag.Error = "Invaled Username or Password";
                }
            }
            return View(user);
        }
        public IActionResult AccountLocked()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
