using RutasNZ_API.Models.Domain;

namespace RutasNZ_API.Repositories
{
    public interface IRutaRepository
    {
        Task<List<Ruta>> GetAllAsync();
        Task<Ruta?> GetAsync(Guid id);
        Task<Ruta> CreateAsync(Ruta ruta);
        Task<Ruta?> UpdateRutaAsync(Guid id, Ruta ruta);
        Task<Ruta?> DeleteAsync(Guid id);
    }
}
