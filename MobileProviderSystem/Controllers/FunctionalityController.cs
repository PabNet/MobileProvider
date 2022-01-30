using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileProviderSystem.AdditionalOptions;
using MobileProviderSystem.Data;
using MobileProviderSystem.Enums;
using MobileProviderSystem.Models.Entities;

namespace MobileProviderSystem.Controllers
{
    public class FunctionalityController : Controller
    {
        private readonly MobileProviderContext _dbContext;
        
        public FunctionalityController(MobileProviderContext dbContext)
        {
            this._dbContext = dbContext;
        }
        
        public IActionResult SystemInformation()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminPanel()
        {
            ViewBag.Roles = this._dbContext.Roles.ToList();
            return View(this._dbContext.Users.Include(u=>u.Account));
        }

        [HttpGet]
        public IActionResult ClientTechnicalSupport()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult ConsultantTechnicalSupport()
        {
            return View();
        }

        [Authorize(Roles = "Client")]
        [HttpGet]
        public IActionResult PersonalArea()
        {
            string login = User.FindFirst(u => u.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            Account account = this._dbContext.Accounts.First(u => u.Login == login);
            return View(this._dbContext.Users
                .Include(u=>u.Account)
                .First(u=>u.Account == account));
        }

        [HttpPost]
        public IActionResult PersonalArea(User user)
        {
            this._dbContext.Database
                .ExecuteSqlInterpolated($"UPDATE Users SET FIO = {user.Fio}, Email = {user.Email}, PhoneNumber = {user.PhoneNumber} WHERE AccountId = {user.AccountId}");
            return RedirectToAction("MainMenu", "Home");
        }
        
        public IActionResult Contacts()
        {
            return View(this._dbContext.SocialNetworkReferences.Include(n=>n.Contact)
                .Include(n => n.SocialNetwork).ToList());
        }
        
        
    }
}