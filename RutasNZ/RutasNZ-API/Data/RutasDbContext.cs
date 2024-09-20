using Microsoft.EntityFrameworkCore;
using RutasNZ_API.Models.Domain;

namespace RutasNZ_API.Data
{
    public class RutasDbContext : DbContext
    {
        public RutasDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Dificultad> Dificultades { get; set; }
        public DbSet<Region> Regiones { get; set; }
        public DbSet<Ruta> Rutas { get; set; }


       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Dummy datos
            var dificultades = new List<Dificultad>()
            {
                new Dificultad()
                {
                    Id_Dificultad = Guid.Parse("755fff32-bca4-4aa3-96d1-22f337c5a673"),
                    Nombre = "Facil"
                },
                new Dificultad()
                {
                    Id_Dificultad = Guid.Parse("755fff32-bca4-4aa3-96d1-22f337c5a099"),
                    Nombre = "Media"
                },
                new Dificultad()
                {
                    Id_Dificultad = Guid.Parse("755fff32-bca4-4aa3-96d1-22f337c5a100"),
                    Nombre = "Dificil"
                }
            };

            var regiones = new List<Region>()
            {
                new Region()
                {
                    Id_Region = Guid.Parse("755fff32-bca4-4aa3-96d1-22f337c5ae01"),
                    Nombre = "Madrid",
                    Codigo = "MD",
                    ImagenRegionUrl = "https://images.pexels.com/photos/1500598/pexels-photo-1500598.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
               new Region()
                {
                    Id_Region = Guid.Parse("755fff22-bca4-4aa3-96d1-22f337c5a551"),
                    Nombre = "Barcelona",
                    Codigo = "BC",
                    ImagenRegionUrl = "https://images.pexels.com/photos/819764/pexels-photo-819764.jpeg"
                }
            };


            // Meter el dummy en la tabla
            modelBuilder.Entity<Dificultad>().HasData(dificultades);
            modelBuilder.Entity<Region>().HasData(regiones);

        }
    }
}
