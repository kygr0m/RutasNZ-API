using RutasNZ_API.Models.Domain;

namespace RutasNZ_API.Repositories
{
    public interface IRutaRepository
    {
        Task<List<Ruta>> GetAllAsync
            (
            string? filtro = null, string? queryFiltro = null, // Filtrado
            string? ordenarPor = null, bool esAcendente = true, // Ordenacion
            int numeroPaginas  = 1, int tamanioPaginas = 10 //  Paginacion
            );
        Task<Ruta?> GetAsync(Guid id);
        Task<Ruta> CreateAsync(Ruta ruta);
        Task<Ruta?> UpdateRutaAsync(Guid id, Ruta ruta);
        Task<Ruta?> DeleteAsync(Guid id);
    }
}
