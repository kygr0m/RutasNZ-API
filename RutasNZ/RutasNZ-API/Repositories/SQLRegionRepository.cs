using Microsoft.EntityFrameworkCore;
using RutasNZ_API.Data;
using RutasNZ_API.Models.Domain;
using RutasNZ_API.Models.DTO.Region;

namespace RutasNZ_API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        // dbcontext
        private readonly RutasDbContext _context;
        public SQLRegionRepository(RutasDbContext _context)
        {
            this._context = _context;
        }

       // Implementaciones

        
        public async Task<List<Region>> GetAllAsync()
        {
            return await _context.Regiones.ToListAsync();
        }

        public async Task<Region?> GetAsync(Guid id)
        {
            return await _context.Regiones.FirstOrDefaultAsync(x => x.Id_Region == id);
        }

        public async Task<Region> CreateAsync(Region region)
        {
           await _context.Regiones.AddAsync(region);
           await _context.SaveChangesAsync();
            return region;

        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
           var regionActual = await _context.Regiones.FirstOrDefaultAsync(x => x.Id_Region == id);

            if (regionActual == null)
            {
                return null;
            }

            // Actualizar el dominio con los datos del DTO

            regionActual.Codigo = region.Codigo;
            regionActual.Nombre = region.Nombre;
            regionActual.ImagenRegionUrl = region.ImagenRegionUrl;

            await _context.SaveChangesAsync();

            return regionActual;

        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var regionExiste = await _context.Regiones.FirstOrDefaultAsync(x  => x.Id_Region == id);
            if (regionExiste == null)
            {
                return null;
            }

            _context.Regiones.Remove(regionExiste);
            await _context.SaveChangesAsync();
            return regionExiste;
        }
    }
}
