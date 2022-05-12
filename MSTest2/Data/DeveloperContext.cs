using Microsoft.EntityFrameworkCore;
using MSTest2.Models;

namespace MSTest2.Data
{
    public class DeveloperContext : DbContext
    {
        public DeveloperContext(DbContextOptions<DeveloperContext> options) : base(options)
        {

        }

        public DbSet<DeveloperModel> DeveloperModels { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //user portion
            modelBuilder.Entity<DeveloperModel>().ToTable("DeveloperModel");

        }
    }
}
