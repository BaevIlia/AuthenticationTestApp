using AuthenticationTestApp.Database;
using AuthenticationTestApp.Database.Entities;
using AuthenticationTestApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationTestApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthTestDbContext _context;

        public UserRepository(AuthTestDbContext context)
        {
            _context = context;
        }
        public async Task Add(User user)
        {
            var userEntity = new UserEntity()
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u=>u.Email==email) ?? throw new Exception();
            //TODO: Плохая реализация, реализовать через Mapper
            User resultUser = User.Create(userEntity.Id, userEntity.UserName, userEntity.PasswordHash, userEntity.Email);
            return resultUser;
        }
    }
}
