using CarDB.Cars;
using CarDB.Owner;
using Microsoft.EntityFrameworkCore;

namespace CarDB
{
    /// <summary>
    /// Context EntityFrameWork
    /// </summary>
    public class MyContext : DbContext
    {
        private DbSet<Car> _cars;
        private DbSet<Proprietaire> _proprietaires;
        public DbSet<Car> Cars { get => _cars; set => _cars = value; }
        public DbSet<Proprietaire> Proprietaires { get => _proprietaires; set => _proprietaires = value; }

        /// <summary>
        /// Verifiy la base de donnée est bien crée
        /// </summary>
        public MyContext()
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Configuration de la connection avec SQLSERVER
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server=localhost;Database=CarsDB;Integrated Security=SSPI;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Configuration des model de mapping des Class
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasKey(c => c.VoitureId);

            modelBuilder.Entity<Proprietaire>().HasKey(c => c.Name);
        }
    }
}
