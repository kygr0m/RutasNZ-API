using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RutasNZ_API.Models.Domain;
using RutasNZ_API.Models.DTO.Imagen;
using RutasNZ_API.Repositories;

namespace RutasNZ_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenesController : ControllerBase
    {
        private readonly IImagenRepository imagenRepository;

        public ImagenesController( IImagenRepository imagenRepository)
        {
            this.imagenRepository = imagenRepository;
        }

        [HttpPost]
        [Route("Subir")]  //api/Imagenes/Subir
        public async Task<IActionResult> Subir([FromForm] subirImagenDto peticion )
        {
            //Dto a dominio
            var imagenDominio = new Imagen
            {
                Fichero = peticion.Fichero,
                nombreFichero = peticion.nombreFichero,
                descripcionFichero = peticion.descripcionFichero,
                extensionFichero  = Path.GetExtension(peticion.Fichero.FileName)
            };
            // Repositorio para subir la imagen
            await imagenRepository.Subir(imagenDominio);
            return Ok(imagenDominio);

        }

        
    }
}
