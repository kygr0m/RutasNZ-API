using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RutasNZ_API.Data;
using RutasNZ_API.Models.Domain;
using RutasNZ_API.Models.DTO;
using RutasNZ_API.Models.DTO.Region;
using RutasNZ_API.Repositories;
using System.Runtime.Intrinsics.Arm;

namespace RutasNZ_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly RutasDbContext _dbContext;
        private readonly IRegionRepository _regionRepository;
        public RegionController(RutasDbContext _dbContext, IRegionRepository _regionRepository)
        {
            this._dbContext = _dbContext;
            this._regionRepository = _regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Dominio
            var regiones = await _regionRepository.GetAllAsync();

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
            var region = await _regionRepository.GetAsync(id);

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

            dominioRegion = await _regionRepository.CreateAsync(dominioRegion);

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

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ActualizarRegionDto actualizarDto)
        {
            // DTO a dominio

            var dominioModeloRegion = new Region
            {
                Codigo = actualizarDto.Codigo,
                Nombre = actualizarDto.Nombre,
                ImagenRegionUrl = actualizarDto.ImagenRegionUrl
            };

            // Comprobacion si existe 

            dominioModeloRegion = await _regionRepository.UpdateAsync(id, dominioModeloRegion);
            if (dominioModeloRegion == null)
            {
                return NotFound();
            }

            // Pasar el dominio a DTO para retornarlo

            var regionDto = new RegionDto
            {
                Id = dominioModeloRegion.Id_Region,
                Codigo = dominioModeloRegion.Codigo,
                Nombre = dominioModeloRegion.Nombre,
                ImagenUrl = dominioModeloRegion.ImagenRegionUrl

            };

            return Ok(dominioModeloRegion);


        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Borrar([FromRoute]Guid id) 
        {

            // Comprobar que exista

            var regionDominio = await _regionRepository.DeleteAsync(id);

            if (regionDominio == null)
            {
                return NotFound();
            }

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
