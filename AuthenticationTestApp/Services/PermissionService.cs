using AuthenticationTestApp.Database.Enums;
using AuthenticationTestApp.Interfaces;

namespace AuthenticationTestApp.Services
{
    public class PermissionService
    {
        private readonly IUserRepository _userRepository;

        public PermissionService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<HashSet<Permission>> GetPermissionsAsync(Guid userId)
        {
            return _userRepository.GetUserPermissions(userId);
        }
    }
}
