using E_commerce.Helpers;
using E_commerce.Security.Authorization.Requirements;
using E_commerce.Shared;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Security.Authorization.Handlers
{
    public class AdminRoleHandler : AuthorizationHandler<AdminRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                    AdminRoleRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == JwtClaimTypes.Role &&
                                            c.Issuer == WebHostHelper.GetWebUrl()))
            {
                return Task.CompletedTask;
            }

            var adminClaim = context.User.FindFirst(c => c.Type == JwtClaimTypes.Role &&
                                                      c.Issuer == WebHostHelper.GetWebUrl() &&
                                                      c.Value == SecurityConstants.ADMINISTRATION_ROLE).Value;

            if (!string.IsNullOrEmpty(adminClaim))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
