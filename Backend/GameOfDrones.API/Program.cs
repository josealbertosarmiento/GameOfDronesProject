using Microsoft.EntityFrameworkCore;
using GameOfDrones.API.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. SERVICIOS BÁSICOS
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. CONFIGURACIÓN DE BASE DE DATOS
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. DEFINICIÓN DE CORS (ESTO ES LO QUE TE FALTABA)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// 4. CREACIÓN DE TABLAS Y CARGA DE DATOS (SEED)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    // Asegura que la DB exista
    context.Database.EnsureCreated(); 

    try 
    {
        // Si la tabla Moves no tiene datos, los insertamos
        if (!context.Moves.Any())
        {
            context.Moves.AddRange(
                new Move { Name = "Rock", Kills = "Scissors" },
                new Move { Name = "Paper", Kills = "Rock" },
                new Move { Name = "Scissors", Kills = "Paper" }
            );
            context.SaveChanges();
        }
    }
    catch (Exception)
    {
        // En caso de error de DB, la app seguirá corriendo
    }
}

// 5. MIDDLEWARE (EL ORDEN AQUÍ ES CRÍTICO)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// UseCors debe ir DESPUÉS de UseHttpsRedirection y ANTES de MapControllers
app.UseCors("AllowAngular"); 

app.UseAuthorization();
app.MapControllers();

app.Run();