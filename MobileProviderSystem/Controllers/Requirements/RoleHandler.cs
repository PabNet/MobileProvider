using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MobileProviderSystem.Controllers.Requirements
{
    public class RoleHandler : AuthorizationHandler<RoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == ClaimTypes.Role))
            {
                string role = context.User.FindFirst(u => u.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                foreach (var page in RoleRequirement.RoleAccess)
                {
                    foreach (var rolePage in page.Value)
                    {
                        if (rolePage.Contains(role))
                        {
                            context.Succeed(requirement);
                        }
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}