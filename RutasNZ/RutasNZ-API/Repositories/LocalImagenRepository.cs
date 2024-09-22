using RutasNZ_API.Data;
using RutasNZ_API.Models.Domain;

namespace RutasNZ_API.Repositories
{
    public class LocalImagenRepository : IImagenRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly RutasDbContext context;

        public LocalImagenRepository(IWebHostEnvironment webHostEnvironment,  IHttpContextAccessor contextAccessor,RutasDbContext context)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.contextAccessor = contextAccessor;
            this.context = context;
        }
        public async Task<Imagen> Subir(Imagen imagen)
        {

            var pathFicheroEnLocal = Path.Combine(webHostEnvironment.ContentRootPath,"Imagenes",$"{imagen.nombreFichero}{imagen.extensionFichero}");

            //  Pasar la imagen a la carpeta local
            using var steam = new FileStream(pathFicheroEnLocal, FileMode.Create);
            await imagen.Fichero.CopyToAsync(steam);

            //Formar URL >> https://localhost:1234/imagenes/imagen.png

            var urlImagen = $"{contextAccessor.HttpContext.Request.Scheme}://{contextAccessor.HttpContext.Request.Host}{contextAccessor.HttpContext.Request.PathBase}/Imagenes/{imagen.nombreFichero}{imagen.extensionFichero}";
                                // Http o  Https
       
            imagen.pathFichero = urlImagen;

            // Agregar el path de  la imagen  en la base de datos

            await context.Imagenes.AddAsync(imagen);
            await context.SaveChangesAsync();

            return imagen;

        }
    }
}
