using RutasNZ_API.Models.Domain;
using RutasNZ_API.Models;

namespace RutasNZ_API.Models.DTO.Ruta
{
    public class AgregarRutaDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public double LongitudKm { get; set; }
        public string? ImagenRutaUrl { get; set; }
        public Guid Id_Dificultad { get; set; }
        public Guid Id_Region { get; set; }
    }
}
