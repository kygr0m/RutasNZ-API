using Rutas.UI.Models.DTO;

namespace Rutas.UI.Models
{
    public class AgregarRutaVista
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public double LongitudKm { get; set; }
        public string? ImagenRutaUrl { get; set; }
        public Guid Id_Dificultad { get; set; }
        public Guid Id_Region { get; set; }

        public RegionDto Region { get; set; }
        public DificultadDto Dificultad { get; set; }
    }
}
