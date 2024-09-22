using RutasNZ_API.Models.Domain;

namespace RutasNZ_API.Repositories
{
    public interface IImagenRepository
    {

        Task<Imagen> Subir(Imagen imagen);
    }
}
