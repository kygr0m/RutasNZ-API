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
            await dbcontext.Rutas.AddAsync(ruta);
            await dbcontext.SaveChangesAsync();
            return ruta;
        }

        public Task<List<Ruta>> GetAllAsync()
        {
            throw new NotImplementedException();
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
