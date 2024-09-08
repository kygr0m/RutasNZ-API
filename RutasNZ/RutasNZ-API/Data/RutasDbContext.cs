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
    }
}
