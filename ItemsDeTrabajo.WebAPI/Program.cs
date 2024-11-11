using Microsoft.EntityFrameworkCore;
using ItemsDeTrabajo.Data.Contexto;
using ItemsDeTrabajo.Data.Interfaces;
using ItemsDeTrabajo.Data.Repositorio;
using ItemsDeTrabajo.Servicios.Interfaces;
using ItemsDeTrabajo.Servicios.Servicio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ItemTrabajoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), conexion => conexion.MigrationsAssembly("ItemsDeTrabajo.WebAPI")));

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<IItemTrabajoRepositorio, ItemTrabajoRepositorio>();
builder.Services.AddScoped<IItemTrabajoServicio, ItemTrabajoServicio>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
