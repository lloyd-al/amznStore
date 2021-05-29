using amznStore.Services.UserAuthentication.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace amznStore.Services.UserAuthentication.Infrastructure.DataContexts
{
    public class UserDbContext : IdentityDbContext<ApplicationUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserPaymentCard> UserPaymentCards { get; set; }
    }
}

