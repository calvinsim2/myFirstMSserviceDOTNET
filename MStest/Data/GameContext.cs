using Microsoft.EntityFrameworkCore;
using MStest.Models;

namespace MStest.Data
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {

        }
        
        public DbSet<GameModel> GameModels { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //user portion
            modelBuilder.Entity<GameModel>().ToTable("GameModel");
            
        }
    }
}
