using amznStore.Services.UserAuthentication.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace amznStore.Services.UserAuthentication.Infrastructure.DataContexts
{
    public class UserDbContextSeed
    {
        public static async Task SeedEssentialsAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            if (!roleManager.RoleExistsAsync(UserRole.ADMIN).Result)
            {
                await roleManager.CreateAsync(new IdentityRole(UserRole.ADMIN));
                await roleManager.CreateAsync(new IdentityRole(UserRole.USER));
                await roleManager.CreateAsync(new IdentityRole(UserRole.SELLER));
            }

            //Seed Default User
            var defaultUser = new ApplicationUser {
                FirstName = "Lloyd",
                LastName = "Almeida",
                UserName = "admin@amznstore.com",
                Email = "admin@amznstore.com", 
                EmailConfirmed = true, 
                PhoneNumberConfirmed = true,
                SecurityStamp = String.Concat(Array.ConvertAll(Guid.NewGuid().ToByteArray(), b => b.ToString("X2")))
        };

            if (userManager.FindByEmailAsync(defaultUser.Email).Result == null)
            {
                IdentityResult result = userManager.CreateAsync(defaultUser, "Password@1234").Result;

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(defaultUser, UserRole.ADMIN);
                }
                    
            }
        }
    }
}
