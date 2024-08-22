using AuthenticationTestApp.Database;
using AuthenticationTestApp.Interfaces;

namespace AuthenticationTestApp.Services
{
    public class UserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository, IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }
        public async Task Register(string userName, string email, string password) 
        {
            var hasgedPassword = _passwordHasher.Generate(password);

            var user = User.Create(Guid.NewGuid(), userName, hasgedPassword, email);

            await _repository.Add(user);
        }

        public async Task<string> Login(string email, string password) 
        {
            var user = await _repository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (!result)
                throw new Exception("Failed to login");
            
        }
    }
}
