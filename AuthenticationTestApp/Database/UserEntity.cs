namespace AuthenticationTestApp.Database
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }

    }
}
