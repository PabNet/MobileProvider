using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MobileProviderSystem.AdditionalOptions;
using MobileProviderSystem.Controllers.Requirements;
using MobileProviderSystem.Data;
using MobileProviderSystem.Enums;
using MobileProviderSystem.Models.Entities;

namespace MobileProviderSystem.Controllers
{
    
    
    public class FunctionalityController : Controller
    {
        private readonly MobileProviderContext _dbContext;
        private readonly IConfiguration _configuration;


        public FunctionalityController(MobileProviderContext dbContext, IConfiguration configuration)
        {
            this._configuration = configuration;
            this._dbContext = dbContext;
        }
        
        [Authorize(Policy = Policies.RoleRequirement)]
        public IActionResult SystemInformation()
        {
            string roleName = User.FindFirst(u => u.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            Role role = this._dbContext.Roles.First(r => r.RoleName == roleName);
            ViewData["Description"] = this._dbContext.Descriptions.First(d => d.RoleId == role.Id).SystemDescription;
            return View();
        }

        [Authorize(Roles = Roles.AdminRole)]
        public IActionResult AdminPanel()
        {
            List<string> roles = new List<string>();
            foreach (var role in this._dbContext.Roles.ToList())
            {
                if (role.RoleName != Roles.AdminRole)
                {
                    roles.Add(role.RoleName);
                }
            }
            ViewBag.Roles = roles;
            return View(this._dbContext.Users.Include(u=>u.Account));
        }
        
        [Authorize(Policy = Policies.RoleRequirement)]
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
        
        [Authorize(Policy = Policies.RoleRequirement)]
        public IActionResult Contacts()
        {
            return View(this._dbContext.Contacts.Include(n=>n.SocialNetwork)
                .Include(n => n.SocialNetwork).ToList());
        }

        public void DeleteUser(ushort UserId)
        {
            User user = this._dbContext.Users.First(u => u.Id == UserId);
            this._dbContext.Users.Remove(user);
            this._dbContext.Accounts.Remove(this._dbContext.Accounts.First(a => a.Id == user.AccountId));
            this._dbContext.SaveChanges();
            
        }

        [Authorize(Roles = Roles.AdminRole)]
        public IActionResult RoleEditor()
        {
            List<Role> roleList = this._dbContext.Roles.ToList();
            roleList.RemoveAll(r => r.RoleName == Roles.AdminRole || r.RoleName == Roles.ClientRole);
            ViewBag.Pages = Pages.Names.Values;
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
        
        [HttpGet]
        public IActionResult AccessRights(string PageName)
        {
            ViewBag.PageRoles = RoleRequirement.RoleAccess[PageName];
            ViewBag.PageName = PageName;
            return View(this._dbContext.Roles.ToList());
        }

        public void UpdateRequirement(string PageName, List<string> Roles)
        {
            RoleRequirement.RoleAccess[PageName].Clear();
            RoleRequirement.RoleAccess[PageName].AddRange(Roles);
        }
        
        
        
        
    }
}