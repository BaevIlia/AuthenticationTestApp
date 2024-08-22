using AuthenticationTestApp.Database;

namespace AuthenticationTestApp.Interfaces
{
    public interface IUserRepository
    {
        public Task Add(User user);
        public Task<User> GetByEmail(string email);
    }
}
