
using AuthenticationTestApp.Database;
using AuthenticationTestApp.Interfaces;
using AuthenticationTestApp.Options;
using AuthenticationTestApp.Repository;
using AuthenticationTestApp.Services;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationTestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            // Add services to the container.
            builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
            builder.Services.AddDbContext<AuthTestDbContext>();
            builder.Services.AddScoped<IJwtProviderService, JwtProviderService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.MapControllers();

            app.Run();
        }
    }
}
