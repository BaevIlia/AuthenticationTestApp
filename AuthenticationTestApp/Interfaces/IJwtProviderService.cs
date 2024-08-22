using AuthenticationTestApp.Database;

namespace AuthenticationTestApp.Interfaces
{
    public interface IJwtProviderService
    {
        string GenerateToken(User user);
    }
}
