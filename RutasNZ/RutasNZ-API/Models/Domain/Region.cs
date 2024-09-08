using System.ComponentModel.DataAnnotations;

namespace RutasNZ_API.Models.Domain
{
    public class Region
    {
        [Key]
        public Guid Id_Region { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Codigo {  get; set; } = string.Empty;
        public string? ImagenRegionUrl { get; set; }

    }
}
