using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RutasNZ_API.Data;
using RutasNZ_API.Models.Domain;
using RutasNZ_API.Models.DTO.Region;
using RutasNZ_API.Models.DTO.Ruta;
using RutasNZ_API.Repositories;

namespace RutasNZ_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutasController : ControllerBase

    {

        private readonly IMapper mapper;
        private readonly IRutaRepository rutarepository;

        public RutasController(IMapper mapper, IRutaRepository rutarepository)
        {
            this.mapper = mapper;
            this.rutarepository = rutarepository;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            // Dominio
            var ruta = await rutarepository.GetAsync(id);

            // DTO 


            if (ruta == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RegionDto>(ruta));
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AgregarRutaDTO agregarRutaDTO)
        {
            // Dominio
            var rutadominio = mapper.Map<Ruta>(agregarRutaDTO);
            var dificultad = await rutarepository.GetDificultadAsync(agregarRutaDTO.Id_Dificultad);
            var region = await rutarepository.GetRegionAsync(agregarRutaDTO.Id_Region);
            rutadominio.Dificultad = dificultad;
            rutadominio.Region = region;
            rutadominio = await rutarepository.CreateAsync(rutadominio);

            var rutadto = mapper.Map<RutaDTO>(rutadominio);
            // CreatedAtAction >> codigo 201
            return CreatedAtAction(nameof(Get), new { id = rutadominio.Id_ruta }, rutadto);
        }


    };
           
        }
