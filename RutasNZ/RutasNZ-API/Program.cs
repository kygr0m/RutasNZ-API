using Microsoft.EntityFrameworkCore;
using RutasNZ_API.Data;
using RutasNZ_API.Mappings;
using RutasNZ_API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection DBConnectionString
builder.Services.AddDbContext<RutasDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionRutas")));

// Inyeccion interfaz Region usando la implementacion
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
builder.Services.AddScoped<IRutaRepository, SQLRutaRepository>();


// Agregar los perfiles del automapper al iniciar el programa
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
