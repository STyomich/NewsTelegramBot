using Core.Entities;
using Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<UserData> UserData { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            DbSeeder.Seed(modelBuilder);
        }
    }
}