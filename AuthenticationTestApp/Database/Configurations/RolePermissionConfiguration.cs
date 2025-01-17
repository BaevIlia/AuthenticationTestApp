﻿using AuthenticationTestApp.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthenticationTestApp.Options;
using AuthenticationTestApp.Database.Enums;

namespace AuthenticationTestApp.Database.Configurations
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermissionEntity>
    {
        private readonly AuthorizationOptions _authorizationOptions;
        public RolePermissionConfiguration(AuthorizationOptions authorization)
        {
            _authorizationOptions = authorization;
        }
        public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
        {
            builder.HasKey(r => new { r.RoleId, r.PermissionId });
            builder.HasData(ParseRolePermission());
        }
        //TODO: Не генерирует данные
        private RolePermissionEntity[] ParseRolePermission() 
        {
            return _authorizationOptions.RolePermissions
              .SelectMany(rp => rp.Permissions
                .Select(p => new RolePermissionEntity
                {
                    RoleId = (int)Enum.Parse<Role>(rp.Role),
                    PermissionId = (int)Enum.Parse<Permission>(p)
                })).ToArray();
                    
        }
    }
}
