using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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

        public async Task<List<Ruta>> GetAllAsync(string? filtro = null, string? queryFiltro = null,
                                                  string? ordenarPor = null, bool esAcendente = true,
                                                  int numeroPaginas = 1, int tamanioPaginas = 10)
        {
            // Filtrado por nombre y longitud
            var rutas = dbcontext.Rutas.Include("Dificultad").Include("Region").AsQueryable();

            //Filtrado
            if (!string.IsNullOrWhiteSpace(filtro) && !string.IsNullOrWhiteSpace(queryFiltro))
            {
                if (filtro.Equals("Nombre", StringComparison.OrdinalIgnoreCase)) //   nomBre, NOMbre
                {
                    rutas = rutas.Where(x => x.Nombre.Contains(queryFiltro));
                }
                else if (filtro.Equals("LongitudKm", StringComparison.OrdinalIgnoreCase))
                {
                    if (double.TryParse(queryFiltro, out double longitud))
                    {
                        rutas = rutas.Where(x => x.LongitudKm == longitud);
                    }
                    else
                    {
                        return new List<Ruta>();
                    }
                }
                else
                {
                    return new List<Ruta>();
                }
            }

            // Ordenacion

            if (!string.IsNullOrWhiteSpace(ordenarPor))
            { 
                if (ordenarPor.Equals("Nombre", StringComparison.OrdinalIgnoreCase))
                {
                    rutas  = esAcendente ? rutas.OrderBy(x => x.Nombre) : rutas.OrderByDescending(x => x.Nombre);
                }
                else if (ordenarPor.Equals("LongitudKm", StringComparison.OrdinalIgnoreCase))
                {
                    rutas = esAcendente ? rutas.OrderBy(x => x.LongitudKm) : rutas.OrderByDescending(x => x.LongitudKm);
                }
            }

            //  Paginacion

            var saltarResultado = (numeroPaginas - 1) * tamanioPaginas;             

            return await rutas. Skip(saltarResultado).Take(tamanioPaginas).ToListAsync();
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
