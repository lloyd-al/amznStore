using amznStore.Services.UserAuthentication.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amznStore.Services.UserAuthentication.Infrastructure.DataContexts
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = UserRole.ADMIN,
                    NormalizedName = UserRole.ADMIN
                },
                new IdentityRole
                {
                    Name = UserRole.USER,
                    NormalizedName = UserRole.USER
                }
                ,
                new IdentityRole
                {
                    Name = UserRole.SELLER,
                    NormalizedName = UserRole.SELLER
                }
             );
        }
    }
}
