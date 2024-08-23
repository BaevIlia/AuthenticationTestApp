using AuthenticationTestApp.Database;
using AuthenticationTestApp.Database.Enums;

namespace AuthenticationTestApp.Interfaces
{
    public interface IUserRepository
    {
        public Task Add(User user);
        public Task<User> GetByEmail(string email);
        public Task<HashSet<Permission>> GetUserPermissions(Guid userId);
    }
}
