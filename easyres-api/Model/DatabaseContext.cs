using Microsoft.EntityFrameworkCore;

namespace easyres_api.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
                           : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Reservatie> Reservaties { get; set; }
        public DbSet<Bestelling> Bestellingen { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Uitbater> Uitbaters { get; set; }
        public DbSet<Sessie> Sessies { get; set; }
    }
}
