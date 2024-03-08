using BackEnd.Repositorio.DBContext;
using Microsoft.EntityFrameworkCore;

using BackEnd.Repositorio.Contrato;
using BackEnd.Repositorio.Implementacion;

using BackEnd.Utilidades;

using BackEnd.Servicio.Contrato;
using BackEnd.Servicio.Implementacion;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexión a BD Backend

builder.Services.AddDbContext<DbBackendContext>(options =>

{
    options.UseSqlServer(builder.Configuration.GetConnectionString("con"));

});

// Implementación de Las Interface Interface  -> Clase
// usamos transient porque se usa el tipo genérico (Repositorio)

builder.Services.AddTransient(typeof(IGenericoRepositorio<>),typeof(GenericoRepositorio<>));

// en esta si sabemos que interface será implementada (Si se sabe el modelo)
builder.Services.AddScoped<IVentaRepositorio,VentaRepositorio>();


 //Implementar el AutoMapper para la implementación de las clases en clases DTO y viceversa
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Inyectando los servicios (dependencias)

builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();
builder.Services.AddScoped<IVentaServicio, VentaServicio>();
builder.Services.AddScoped<IDashboardServicio, DashboardServicio>();

// agregaremos cors para evitar errores a la hora de publicar la api y webassembly en el momento de generar consultas

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//usar cors
app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
