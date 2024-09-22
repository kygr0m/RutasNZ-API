using RutasNZ_API.Models.Domain;
using RutasNZ_API.Models;
using System.ComponentModel.DataAnnotations;

namespace RutasNZ_API.Models.DTO.Ruta
{
    public class AgregarRutaDTO
    {
        [Required]
        [MaxLength(80, ErrorMessage = "El nombre tiene que contener un máximo de 80 caracteres")]
        public string Nombre { get; set; } 
        [Required]
        [MaxLength(255, ErrorMessage = "La descripción tiene que contener un máximo de 255 caracteres")]
        public string Descripcion { get; set; }
        [Required]
        [Range(0,120)]
        public double LongitudKm { get; set; } 
        public string? ImagenRutaUrl { get; set; }
        [Required]
        public Guid Id_Dificultad { get; set; }
        [Required]
        public Guid Id_Region { get; set; }
    }
}
