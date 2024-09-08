using System.ComponentModel.DataAnnotations;

namespace RutasNZ_API.Models.Domain
{
    public class Dificultad
    {
        [Key]
        public Guid Id_Dificultad { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
