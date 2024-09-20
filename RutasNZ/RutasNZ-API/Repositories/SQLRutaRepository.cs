using Microsoft.EntityFrameworkCore;
using RutasNZ_API.Data;
using RutasNZ_API.Models.Domain;

namespace RutasNZ_API.Repositories
{
    public class SQLRutaRepository : IRutaRepository
    {
        private readonly RutasDbContext dbcontext;
        public SQLRutaRepository(RutasDbContext dbContext)
        {
            this.dbcontext = dbContext;
        }



        public async Task<Ruta> CreateAsync(Ruta ruta)
        {
            using (var transaction = dbcontext.Database.BeginTransaction())
            {
                try
                {
                    // Recoger region
                    var region = await dbcontext.Regiones.FindAsync(ruta.Id_Region);
                    if (region == null)
                    {
                        throw new InvalidOperationException($"Region with Id_Region {ruta.Id_Region} does not exist");
                    }

                    // Recoger dificultad
                    var dificultad = await dbcontext.Dificultades.FindAsync(ruta.Id_Dificultad);
                    if (dificultad == null)
                    {
                        throw new InvalidOperationException($"Dificultad with Id_Dificultad {ruta.Id_Dificultad} does not exist");
                    }

                    // Crear una nueva ruta
                    ruta.Region = region;
                    ruta.Dificultad = dificultad;
                    dbcontext.Rutas.Add(ruta);
                    await dbcontext.SaveChangesAsync();

                    transaction.Commit();
                    return ruta;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task<List<Ruta>> GetAllAsync()
        {
         return await dbcontext.Rutas.Include("Dificultad").Include("Region").ToListAsync();
            
        }

        public async Task<Ruta?> GetAsync(Guid id)
        {
           return await dbcontext.Rutas
                .Include("Dificultad")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id_ruta == id);


        }

        public async Task<Dificultad> GetDificultadAsync(Guid id)
        {
            return await dbcontext.Dificultades.FindAsync(id);
        }

        public async Task<Region> GetRegionAsync(Guid id)
        {
            return await dbcontext.Regiones.FindAsync(id);
        }

    }
}
