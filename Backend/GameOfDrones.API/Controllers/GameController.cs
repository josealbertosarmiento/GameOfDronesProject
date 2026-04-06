using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameOfDrones.API.Models;

namespace GameOfDrones.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GameController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("moves")]
        public async Task<ActionResult<IEnumerable<Move>>> GetMoves()
        {
            var moves = await _context.Moves.ToListAsync();
        
            if (!moves.Any())
            {
                return Ok(new List<Move> {
                    new() { Name = "Rock", Kills = "Scissors" },
                    new() { Name = "Paper", Kills = "Rock" },
                    new() { Name = "Scissors", Kills = "Paper" }
                });
            }
            return Ok(moves);
        }

        [HttpPost("save-winner")]
        public async Task<IActionResult> SaveWinner([FromBody] WinnerDto data)
        {
            if (data == null || string.IsNullOrEmpty(data.Name)) 
                return BadRequest();

            var player = await _context.Players.FirstOrDefaultAsync(p => p.Name == data.Name);

            if (player == null) 
            {
                _context.Players.Add(new Player { Name = data.Name, Wins = 1 });
            } 
            else 
            {
            
                player.Wins += 1;
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}