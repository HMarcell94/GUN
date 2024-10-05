using LogCommon.Models;
namespace LogCommon
{
    public class SQL : DbContext
    {
        public DbSet<LogEntry> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;User=sa;Password=titok;Database=LoggerDoga;TrustServerCertificate=true;");
        }
    }
}
