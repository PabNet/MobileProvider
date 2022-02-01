using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using MobileProviderSystem.AdditionalOptions;
using MobileProviderSystem.Enums;

namespace MobileProviderSystem.Controllers.Requirements
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public static Dictionary<string, List<string>> RoleAccess { get; set; }

        public RoleRequirement()
        {
            RoleAccess = new Dictionary<string, List<string>>()
            {
                [Pages.Names[PageKeys.PersonalArea]]
                    = new List<string>() { Roles.ClientRole },
                [Pages.Names[PageKeys.Contacts]]
                    = new List<string>() { Roles.ClientRole, Roles.ProductsRole, Roles.ServiceRole },
                [Pages.Names[PageKeys.SystemInformation]]
                    = new List<string>() { Roles.ClientRole, Roles.ProductsRole, Roles.ServiceRole, Roles.MobileInternetRole },
            };
        }

    }
}