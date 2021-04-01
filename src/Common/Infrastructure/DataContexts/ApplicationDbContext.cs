using Microsoft.EntityFrameworkCore;

namespace amznStore.Common.Infrastructure.DataContexts
{
    public abstract class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
