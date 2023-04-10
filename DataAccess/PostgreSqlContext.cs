using Microsoft.EntityFrameworkCore;
using IntexMummy11.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IntexMummy11.DataAccess
{
    public class PostgreSqlContext : IdentityDbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}