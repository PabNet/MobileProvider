using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            string roleName = User.FindFirst(u => u.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            Role role = this._dbContext.Roles.First(r => r.RoleName == roleName);
            ViewData["Description"] = this._dbContext.Descriptions.First(d => d.RoleId == role.Id).SystemDescription;
            return View();
        }

        [Authorize(Roles = "Администратор")]
        public IActionResult AdminPanel()
        {
            List<string> roles = new List<string>() { "" };
            foreach (var role in this._dbContext.Roles.ToList())
            {
                if (role.RoleName != "Администратор")
                {
                    roles.Add(role.RoleName);
                }
            }
            ViewBag.Roles = roles;
            return View(this._dbContext.Users.Include(u=>u.Account));
        }
        
        [Authorize(Roles = "Клиент")]
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
            return View(this._dbContext.Contacts.Include(n=>n.SocialNetwork)
                .Include(n => n.SocialNetwork).ToList());
        }

        public void DeleteUser(ushort UserId)
        {
            this._dbContext.Users.Remove(this._dbContext.Users.First(u=>u.Id == UserId));
            this._dbContext.SaveChanges();
            
        }

        [Authorize(Roles = "Администратор")]
        public IActionResult RoleEditor()
        {
            List<Role> roleList = this._dbContext.Roles.ToList();
            roleList.RemoveAll(r => r.RoleName == "Администратор" || r.RoleName == "Клиент");
            return View(roleList);
        }

        public void DeleteRole(ushort RoleId)
        {
            this._dbContext.Roles.Remove(this._dbContext.Roles.First(r => r.Id == RoleId));
            this._dbContext.SaveChanges(); 
        }

        public void AddRole(List<string> RoleDates)
        {
            Role role = new Role() {RoleName = RoleDates[(int)Indices.Null]};
            this._dbContext.Roles.Add(role);
            this._dbContext.Descriptions.Add(new Description() {SystemDescription = RoleDates[(int)Indices.First], Role = role});
            this._dbContext.SaveChanges();
        }

        public void UpdateRole(List<string> UpdateDates)
        {
            Role role = this._dbContext.Roles.First(r => r.Id == ushort.Parse(UpdateDates[(int)Indices.Null]));
            role.RoleName = UpdateDates[(int) Indices.First];
            this._dbContext.Roles.Update(role);
            this._dbContext.SaveChanges();
        }

        public void UpdateRoleForUser(List<string> UpdateRoleDates)
        {
            Role role = this._dbContext.Roles.First(r => r.RoleName == UpdateRoleDates[(int) Indices.First]);
            User user = this._dbContext.Users.First(u => u.Id == ushort.Parse(UpdateRoleDates[(int) Indices.Null]));
            this._dbContext.Database
                .ExecuteSqlInterpolated($"UPDATE Accounts SET RoleId = {role.Id} WHERE AccountId = {user.AccountId}");
        }
        
        
        
        
    }
}