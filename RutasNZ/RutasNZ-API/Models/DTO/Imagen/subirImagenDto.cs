using System.ComponentModel.DataAnnotations;

namespace RutasNZ_API.Models.DTO.Imagen
{
    public class subirImagenDto
    {
        [Required]
        public IFormFile  Fichero { get; set; }
        [Required]
        public string nombreFichero { get; set; } = string.Empty;
        public string? descripcionFichero { get; set; }
    }
}
