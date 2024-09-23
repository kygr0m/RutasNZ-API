using System.ComponentModel.DataAnnotations;

namespace RutasNZ_API.Models.DTO.Region
{
    public class AgregarRegionDTO
    {
        [Required]
        [MaxLength(80, ErrorMessage = "El nombre tiene que contener un máximo de 80 caracteres")]
        public string Nombre { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "El código tiene que contener un mínimo de 3 caracteres")]
        [MaxLength(5, ErrorMessage = "El código tiene que contener un máximo de 5 caracteres")]
        public string Codigo { get; set; } 
        public string? ImagenRegionUrl { get; set; }
    }
}
