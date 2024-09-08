using System.ComponentModel.DataAnnotations;

namespace RutasNZ_API.Models.Domain
{
    public class Ruta
    {
        [Key]
        public Guid Id_ruta { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public double LongitudKm { get; set; }
        public string? ImagenRutaUrl { get; set; }
        public Guid Id_Dificultad { get; set; }
        public Guid Id_Region { get; set; }

        // Navegacion
        public Dificultad Dificultad { get; set; }
        public Region Region { get; set; }

    }
}
