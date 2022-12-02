namespace MultiplayerTicTacToe.Models
{
    public interface IGameService
    {
        MarkEnum NextTurn { get; set; }
        List<Square> Squares { get; }
        List<string> PlayersNames { get; set; } 
        List<int> PlayersScores { get; set; } 
        MarkEnum? Winner { get; set; }
        Player Player { get; set; }
        Player Opponent { get; set; }
        void FindWinner();
        void ResetGame();
        void UpdateScores();
    }
}