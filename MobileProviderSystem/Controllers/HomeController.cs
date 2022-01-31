using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MobileProviderSystem.AdditionalOptions;
using MobileProviderSystem.Data;
using MobileProviderSystem.Models.Entities;
using MobileProviderSystem.Enums;

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