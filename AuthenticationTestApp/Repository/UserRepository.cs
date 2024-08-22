using AuthenticationTestApp.Database;
using AuthenticationTestApp.Interfaces;

namespace AuthenticationTestApp.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task Add(User user)
        {
            var userEntity = new User()
            {

            }
        }

        public Task<User> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
