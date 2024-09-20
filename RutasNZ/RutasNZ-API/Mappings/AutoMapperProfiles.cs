using AutoMapper;
using RutasNZ_API.Models.Domain;
using RutasNZ_API.Models.DTO.Dificultad;
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
            CreateMap<Dificultad, DificultadDto>().ReverseMap();


            CreateMap<Ruta, RegionDto>()
    .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Region.Nombre))
    .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Region.Codigo))
    .ForMember(dest => dest.ImagenUrl, opt => opt.MapFrom(src => src.Region.ImagenRegionUrl));

        }
    }
}
