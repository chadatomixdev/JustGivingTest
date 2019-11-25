using Microsoft.EntityFrameworkCore;

namespace JG.FinTechTest.Data
{
    /// <summary>
    /// Database Context for Entity Framework
    /// </summary>
    public class JGDBContext : DbContext
    {
        private static bool _created = false;

        public JGDBContext(DbContextOptions options) : base(options)
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
                Database.Migrate();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}