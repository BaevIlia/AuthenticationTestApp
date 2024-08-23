using AuthenticationTestApp.Database.Configurations;
using AuthenticationTestApp.Database.Entities;
using AuthenticationTestApp.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AuthenticationTestApp.Database
{
    //TODO: Не работают миграции, проверить
    public class AuthTestDbContext(
        DbContextOptions<AuthTestDbContext> options,
        IOptions<AuthorizationOptions> authOptions) : DbContext(options)
    {
       
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthTestDbContext).Assembly);
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));
        }


    }
}
