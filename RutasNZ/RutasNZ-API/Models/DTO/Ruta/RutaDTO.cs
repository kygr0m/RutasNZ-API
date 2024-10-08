﻿using RutasNZ_API.Models.DTO.Dificultad;
using RutasNZ_API.Models.DTO.Region;

namespace RutasNZ_API.Models.DTO.Ruta
{
    public class RutaDTO
    {
        public Guid Id_ruta { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public double LongitudKm { get; set; }
        public string? ImagenRutaUrl { get; set; }
        public Guid Id_Dificultad { get; set; }
        public Guid Id_Region { get; set; }

        public RegionDto Region { get; set; }
        public DificultadDto Dificultad { get; set; }
    }
}
