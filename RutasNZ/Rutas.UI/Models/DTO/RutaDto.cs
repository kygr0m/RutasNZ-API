namespace Rutas.UI.Models.DTO
{
    public class RutaDto
    {
        public Guid Id_ruta { get; set; }
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
