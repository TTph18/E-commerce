using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Security.Authorization.Requirements
{
    public class AdminRoleRequirement : IAuthorizationRequirement
    {
        public AdminRoleRequirement() { }
    }
}
