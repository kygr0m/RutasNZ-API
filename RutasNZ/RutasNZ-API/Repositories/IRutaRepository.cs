using RutasNZ_API.Models.Domain;

namespace RutasNZ_API.Repositories
{
    public interface IRutaRepository
    {
        Task<List<Ruta>> GetAllAsync();
        Task<Ruta?> GetAsync(Guid id);
        Task<Ruta> CreateAsync(Ruta ruta);
        Task<Dificultad> GetDificultadAsync(Guid id);
        Task<Region> GetRegionAsync(Guid id);
    }
}
