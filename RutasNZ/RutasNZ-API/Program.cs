using Microsoft.EntityFrameworkCore;
using RutasNZ_API.Data;
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

/* 
 
 AddScoped: This method registers a service with the DI container,
 specifying the lifetime of the service as scoped. 
 A scoped service is created once per request and is disposed of at the end of the request.
 */

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
