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
                    // Retrieve the Region entity
                    var region = await dbcontext.Regiones.FindAsync(ruta.Id_Region);
                    if (region == null)
                    {
                        throw new InvalidOperationException($"Region with Id_Region {ruta.Id_Region} does not exist");
                    }

                    // Retrieve the Dificultad entity
                    var dificultad = await dbcontext.Dificultades.FindAsync(ruta.Id_Dificultad);
                    if (dificultad == null)
                    {
                        throw new InvalidOperationException($"Dificultad with Id_Dificultad {ruta.Id_Dificultad} does not exist");
                    }

                    // Create the Ruta entity
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
         return await dbcontext.Rutas.ToListAsync();
            
        }

        public Task<Ruta?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
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
