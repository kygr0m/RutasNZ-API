using AutoMapper;
using RutasNZ_API.Models.Domain;
using RutasNZ_API.Models.DTO.Region;
using RutasNZ_API.Models.DTO.Ruta;

namespace RutasNZ_API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // reversemap viceversa
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AgregarRegionDTO, Region>().ReverseMap();
            CreateMap<ActualizarRegionDto, Region>().ReverseMap();
            CreateMap<AgregarRutaDTO, Ruta>().ReverseMap();
            CreateMap<Ruta, RutaDTO>().ReverseMap();
        }
    }
}
