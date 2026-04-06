namespace GameOfDrones.API.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Wins { get; set; }
    }

    public class Move
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Kills { get; set; } = string.Empty;
    }

    public class WinnerDto 
    {
        public string Name { get; set; } = string.Empty;
    }
}