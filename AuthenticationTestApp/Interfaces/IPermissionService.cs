using AuthenticationTestApp.Database.Enums;

namespace AuthenticationTestApp.Interfaces
{
    public interface IPermissionService
    {
        public Task<HashSet<Permission>> GetPermissionsAsync(Guid userId);
    }
}
