using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RutasNZ_API.Data;
using RutasNZ_API.Models.Domain;
using RutasNZ_API.Models.DTO;
using RutasNZ_API.Models.DTO.Region;
using System.Runtime.Intrinsics.Arm;

namespace RutasNZ_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private RutasDbContext _dbContext;
        public RegionController(RutasDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Dominio
            var regiones = await _dbContext.Regiones.ToListAsync();

            // DTO
            var regionesDTO = new List<RegionDto>();
            foreach (var region in regiones)
            {
                regionesDTO.Add(new RegionDto()
                {
                    Id = region.Id_Region,
                    Nombre = region.Nombre,
                    Codigo = region.Codigo,
                    ImagenUrl = region.ImagenRegionUrl
                });
            }


            return Ok(regionesDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            // Dominio
            var region = await _dbContext.Regiones.FirstOrDefaultAsync(x => x.Id_Region == id);

            // DTO 

            var regionDto = new RegionDto()
            {
                Id = region.Id_Region,
                Nombre = region.Nombre,
                Codigo = region.Codigo,
                ImagenUrl = region.ImagenRegionUrl

            };

            if (regionDto == null)
            {
                return NotFound();
            }
            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]  AgregarRegionDTO agregarregionDto)
        {
            // Convertir DTO a modelo de dominio

            var dominioRegion = new Region
            {
                Codigo = agregarregionDto.Codigo,
                Nombre = agregarregionDto.Nombre,
                ImagenRegionUrl = agregarregionDto.ImagenUrl

            };

            // Usar dominio para crear una region

            await _dbContext.Regiones.AddAsync(dominioRegion); 
            await _dbContext.SaveChangesAsync();

            // Dominio a DTO

            var regionDTO = new RegionDto
            {
                Id = dominioRegion.Id_Region,
                Codigo = dominioRegion.Codigo,
                Nombre = dominioRegion.Nombre,
                ImagenUrl = dominioRegion.ImagenRegionUrl
            };
            // CreatedAtAction >> codigo 201
            return CreatedAtAction(nameof(Get), new {id = regionDTO.Id}, regionDTO);

        }

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Actualizar([FromRoute] Guid id, [FromBody] ActualizarRegionDto actualizarDto)
        {
            // Comprobacion si existe 
            
            var dominioModeloRegion = await _dbContext.Regiones.FirstOrDefaultAsync(x => x.Id_Region == id);
            
            if (dominioModeloRegion == null)
            {
                return NotFound();
            }

            // Actualizar el dominio con los datos del DTO

            dominioModeloRegion.Codigo = actualizarDto.Codigo;
            dominioModeloRegion.Nombre = actualizarDto.Nombre;
            dominioModeloRegion.ImagenRegionUrl = actualizarDto.ImagenRegionUrl;

           await _dbContext.SaveChangesAsync();

            // Pasar el dominio a DTO para returnarlo

            var regionDto = new RegionDto
            {
                Id = dominioModeloRegion.Id_Region,
                Codigo = dominioModeloRegion.Codigo,
                Nombre = dominioModeloRegion.Nombre,
                ImagenUrl = dominioModeloRegion.ImagenRegionUrl

            };

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Borrar([FromRoute]Guid id) 
        {

            // Comprobar que exista

            var regionDominio = _dbContext.Regiones.FirstOrDefault(x => x.Id_Region == id);

            if (regionDominio == null)
            {
                return NotFound();
            }

            // Borrar 

            _dbContext.Regiones.Remove(regionDominio);
            await _dbContext.SaveChangesAsync();

            var regionDto = new RegionDto
            {
                Id = regionDominio.Id_Region,
                Codigo = regionDominio.Codigo,
                Nombre = regionDominio.Nombre,
                ImagenUrl = regionDominio.ImagenRegionUrl

            };

            return Ok(regionDto);

        }


    }
}
