using AuthenticationTestApp.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationTestApp.Database
{
    //TODO: Не работают миграции, проверить
    public class AuthTestDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        
        public AuthTestDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Database"));
        }

       
    }
}
