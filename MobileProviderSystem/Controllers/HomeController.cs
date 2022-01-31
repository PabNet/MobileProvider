using Microsoft.AspNetCore.Mvc;

namespace MobileProviderSystem.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return RedirectToAction("Authorization","Account");
        }

        public IActionResult MainMenu()
        {
            return View();
        }



    }
}