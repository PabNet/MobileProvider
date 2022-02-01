using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace MobileProviderSystem.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult LoginError()
        {
            return View();
        }
        
        public IActionResult RegistrationError()
        {
            return View();
        }

        public IActionResult AccessError()
        {
            ViewData["Role"] = User.FindFirst(u => u.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            return View();
        }
    }
}