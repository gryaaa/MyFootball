using Microsoft.EntityFrameworkCore;


namespace MyFootball
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Match> Matches { get; set; } = null!;
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
    }
}
