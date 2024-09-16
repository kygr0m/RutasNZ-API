using RutasNZ_API.Models.Domain;
using RutasNZ_API.Models.DTO.Region;

namespace RutasNZ_API.Repositories
{
    public interface IRegionRepository
    {
        // Definiciones de los metodos
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetAsync(Guid id);
        Task<Region> CreateAsync(Region region); 
        Task<Region?> UpdateAsync(Guid id, Region region);    
        Task<Region?> DeleteAsync(Guid id);
    }
}
