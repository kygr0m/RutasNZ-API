using System.ComponentModel.DataAnnotations.Schema;

namespace RutasNZ_API.Models.Domain
{
    public class Imagen
    {
        public Guid Id { get; set; }
        //No se incluye la imagen en la base de datos
        [NotMapped]
        public IFormFile Fichero { get; set; }
        public string nombreFichero { get; set; } = string.Empty;
        public string extensionFichero { get; set; } = string.Empty;
        public string? descripcionFichero { get; set; }
        public string pathFichero { get; set; }


    }
}
