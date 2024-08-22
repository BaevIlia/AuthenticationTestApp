using AuthenticationTestApp.Database;
using AuthenticationTestApp.Interfaces;

namespace AuthenticationTestApp.Services
{
    public class UserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _repository;
        private readonly IJwtProviderService _jwtProviderService;
        public UserService(IUserRepository repository, IPasswordHasher passwordHasher, IJwtProviderService jwtProviderService)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
            _jwtProviderService = jwtProviderService;
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

            var token = _jwtProviderService.GenerateToken(user);

            return token;
        }
    }
}
