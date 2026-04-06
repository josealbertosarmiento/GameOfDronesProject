using Microsoft.EntityFrameworkCore;

namespace GameOfDrones.API.Models
{

    public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<Move> Moves { get; set; } = null!; // <--- Esta es la que te falta
}
}