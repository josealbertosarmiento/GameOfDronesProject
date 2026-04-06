using Microsoft.EntityFrameworkCore;
using GameOfDrones.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    context.Database.EnsureCreated(); 

    try 
    {
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
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("AllowAngular"); 

app.UseAuthorization();
app.MapControllers();

app.Run();