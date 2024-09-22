using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using RutasNZ_API.Data;
using RutasNZ_API.Mappings;
using RutasNZ_API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI DBConnectionString
builder.Services.AddDbContext<RutasDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionRutas")));

// Inyeccion interfaz Region usando la implementacion
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
builder.Services.AddScoped<IRutaRepository, SQLRutaRepository>();
builder.Services.AddScoped<IImagenRepository, LocalImagenRepository>();


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

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Imagenes")),
    RequestPath = "/Imagenes"
});

app.MapControllers();

app.Run();
