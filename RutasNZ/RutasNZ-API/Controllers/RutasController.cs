using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RutasNZ_API.Data;
using RutasNZ_API.Models.Domain;
using RutasNZ_API.Models.DTO.Region;
using RutasNZ_API.Models.DTO.Ruta;
using RutasNZ_API.Repositories;
using System.Diagnostics.SymbolStore;

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AgregarRutaDTO addWalkRequestDto)
        {

            //Validacion del DTO
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Ruta>(addWalkRequestDto);

            await rutarepository.CreateAsync(walkDomainModel);

            // Map Domain model to DTO
            return Ok(mapper.Map<RutaDTO>(walkDomainModel));
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
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


       [HttpGet]
       public async Task<IActionResult> GetAll()
        {
            var rutasdominio = await rutarepository.GetAllAsync();
            return Ok(mapper.Map<List<RutaDTO>>(rutasdominio));
        }

      

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, ActualizarRutaDTO actualizarRutaDto) 
        {
            //Validacion del DTO
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // DTO a dominio

            var rutaDominio = mapper.Map<Ruta>(actualizarRutaDto);

            rutaDominio = await rutarepository.UpdateRutaAsync(id, rutaDominio);

            if (rutaDominio == null)
                return NotFound();

            return Ok(mapper.Map<RutaDTO>(rutaDominio));

        
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete (Guid id)
        {
           var rutaborrada  = await rutarepository.DeleteAsync(id);

            if (rutaborrada == null) { return NotFound(); }

            return Ok(mapper.Map<RutaDTO>(rutaborrada));


        }


    }
           
  }
