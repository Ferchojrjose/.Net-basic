// Importaciones necesarias.
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using EntityFramework;


// Construyendo la aplicación.
var builder = WebApplication.CreateBuilder(args); 

// Conexion base de datos en memoria.
// builder.Services.AddDbContext<TaskContext>(options => options.UseInMemoryDatabase("TareaDB"));

// Conexion base de datos SQL Server.
builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("cnTaskDB"));
// builder.Services.AddSqlServer<TaskContext>("Data Source=servidor_local;Initial Catalog=nombre_base_datos;user id=usuario;password=contraseña");


// Creando la aplicación.
var app = builder.Build(); 

app.MapGet("/", () => "Hello World!");

// Agregando un endpoint para verificar la conexión a la base de datos.
app.MapGet("/dbconexion", async ([FromServices] TaskContext dbContext) => {
    
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.Run();
