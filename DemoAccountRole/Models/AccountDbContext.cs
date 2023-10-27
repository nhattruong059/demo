using Microsoft.EntityFrameworkCore;

namespace DemoAccountRole.Models
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account>? Accounts { get; set; }
    }
}
