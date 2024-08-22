using Microsoft.EntityFrameworkCore;

namespace AuthenticationTestApp.Database
{
    public class AuthTestDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Database"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
