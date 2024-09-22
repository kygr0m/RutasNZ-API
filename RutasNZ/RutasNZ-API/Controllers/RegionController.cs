using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RutasNZ_API.CustomActionFilters;
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
        private readonly IMapper mapper;
        public RegionController(RutasDbContext _dbContext, IRegionRepository _regionRepository,
            IMapper mapper)
        {
            this._dbContext = _dbContext;
            this._regionRepository = _regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Dominio
            var regiones = await _regionRepository.GetAllAsync();

            // DTO
            var regionesDTO = mapper.Map<List<RegionDto>>(regiones);

            return Ok(regionesDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            // Convertir el parametetro de la ruta a Guid
            Guid regionId = Guid.Parse(id);

            // Dominio
            var region = await _regionRepository.GetAsync(regionId);

            // DTO
            var regionDTO = mapper.Map<RegionDto>(region);

            if (region == null)
            {
                return NotFound();
            }

            return Ok(regionDTO);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AgregarRegionDTO agregarregionDto)
        {
          
            // Convertir DTO a modelo de dominio
            var dominioRegion = mapper.Map<Region>(agregarregionDto);

            // Usar dominio para crear una region
            dominioRegion = await _regionRepository.CreateAsync(dominioRegion);

            // Dominio a DTO
            var regionDTO = mapper.Map<RegionDto>(dominioRegion);

            // CreatedAtAction >> codigo 201
            return CreatedAtAction(nameof(Get), new { id = regionDTO.Id_Region.ToString() }, regionDTO);
        }

        [HttpPut]
        [Route("{id}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] ActualizarRegionDto actualizarDto)
        {
           
            // Convertir el parametetro de la ruta a Guid
            Guid regionId = Guid.Parse(id);

            // DTO a dominio
            var dominioModeloRegion = mapper.Map<Region>(actualizarDto);

            // Comprobacion si existe
            dominioModeloRegion = await _regionRepository.UpdateAsync(regionId, dominioModeloRegion);

            if (dominioModeloRegion == null)
            {
                return NotFound();
            }

            // Pasar el dominio a DTO para retornarlo
            var regionDTO = mapper.Map<RegionDto>(dominioModeloRegion);

            return Ok(regionDTO);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Borrar([FromRoute] string id)
        {
            // Convertir el parametetro de la ruta a Guid
            Guid regionId = Guid.Parse(id);

            // Comprobar que exista
            var regionDominio = await _regionRepository.DeleteAsync(regionId);

            if (regionDominio == null)
            {
                return NotFound();
            }

            // Pasar el dominio a DTO para retornarlo
            var regionDTO = mapper.Map<RegionDto>(regionDominio);

            return Ok(regionDTO);
        }
    }
}