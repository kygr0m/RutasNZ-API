﻿namespace RutasNZ_API.Models.DTO.Region
{
    public class RegionDto
    {
        public Guid Id_Region { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public string? ImagenRegionUrl { get; set; }
    }
}
