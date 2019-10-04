using Microsoft.EntityFrameworkCore;

namespace CoursesDatabase
{
    public class SchoolContext : DbContext
    {
        private const string connectionString = "Server=localhost;Database=CoursesDatabase;Trusted_Connection=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.UseSqlServer(connectionString);
        }
        public DbSet<Kurs> Kurser { get; set; }
        public DbSet<Elev> Elever { get; set; }
        public DbSet<Larare> Larare { get; set; }
        public DbSet<KursElev> KursElev { get;set; }
        public DbSet<Betyg> Betyg { get; set; }
    }
}
