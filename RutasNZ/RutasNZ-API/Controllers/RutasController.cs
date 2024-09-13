using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RutasNZ_API.Data;
using RutasNZ_API.Models.Domain;

namespace RutasNZ_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutasController : ControllerBase

    {
        private RutasDbContext _dbContext;
        public RutasController(RutasDbContext _dbContext)
        { 
            this._dbContext = _dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var rutas = new List<Ruta>()
            {
                new Ruta
                {
                    Id_ruta = Guid.NewGuid(),
                    Nombre = "Prueba",
                    Descripcion = "Prueba",
                    LongitudKm = 200,
                    ImagenRutaUrl = "Prueba",
                    Id_Dificultad = Guid.NewGuid(),
                    Id_Region = Guid.NewGuid()
                }
            };
            return Ok(rutas);
        }
    };
           
        }
