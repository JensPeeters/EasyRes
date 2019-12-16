using Microsoft.EntityFrameworkCore;

namespace Data_layer.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
                           : base(options)
        {

        }
        public DatabaseContext()
        {

        }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Reservatie> Reservaties { get; set; }
        public virtual DbSet<Bestelling> Bestellingen { get; set; }
        public virtual DbSet<Gebruiker> Gebruikers { get; set; }
        public virtual DbSet<Uitbater> Uitbaters { get; set; }
        public virtual DbSet<Sessie> Sessies { get; set; }
        public virtual DbSet<Factuur> Facturen { get; set; }
    }
}
