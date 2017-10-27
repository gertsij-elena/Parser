using System.Data.Entity;


namespace Parser.Models
{
    public class DataContext:DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}