using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace G2G1FinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.uName = HttpContext.Session.GetString("uName");
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
    }
}
