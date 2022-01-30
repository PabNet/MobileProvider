using Microsoft.AspNetCore.Mvc;

namespace MobileProviderSystem.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ErrorPage(string? TypeError, string? Message)
        {
            return View();
        }
        
        
    }
}