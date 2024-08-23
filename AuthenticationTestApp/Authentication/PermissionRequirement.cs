using AuthenticationTestApp.Database.Enums;
using Microsoft.AspNetCore.Authorization;
using System.Security;

namespace AuthenticationTestApp.Authentication
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionRequirement(Permission[] permissions)
        {
            Permissions = permissions;
        }
        public Permission[] Permissions { get; set; } = [];
    }
}
