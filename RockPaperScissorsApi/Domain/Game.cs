namespace RockPaperScissorsApi.Domain
{
    public class Game
    {
        public int Id { get; set; }

        public string Player1 { get; set; }

        public string Player2 { get; set; }

        public GameStatus Status { get; set; }
    }
}