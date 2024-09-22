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

        public  async Task<Ruta?> DeleteAsync(Guid id)
        {
          var rutaExistente  = await dbcontext.Rutas.FirstOrDefaultAsync(x => x.Id_ruta == id);

            if (rutaExistente == null)
            {      
                return null;

            }
            dbcontext.Rutas.Remove(rutaExistente);
            await dbcontext.SaveChangesAsync();
            return rutaExistente;

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

      

        public async Task<Ruta?> UpdateRutaAsync(Guid id, Ruta ruta)
        {
            var existeRuta = await dbcontext.Rutas.FirstOrDefaultAsync(x => x.Id_ruta == id);

            if (existeRuta  == null) 
            { 
                return null;
            }

            // Machacar valores
            existeRuta.Nombre = ruta.Nombre;
            existeRuta.LongitudKm  = ruta.LongitudKm;
            existeRuta.Descripcion = ruta.Descripcion;
            existeRuta.ImagenRutaUrl = ruta?.ImagenRutaUrl;
            existeRuta.Id_Dificultad = ruta.Id_Dificultad;
            existeRuta.Id_Region     = ruta.Id_Region;

            await dbcontext.SaveChangesAsync(); 

            return ruta;


           
        }
    }
}
