namespace MultiplayerTicTacToe.Models
{
    public class GameService : IGameService
    {
        public List<WinningCombination> WinningCombinations = new List<WinningCombination>
        {
            new WinningCombination(1, 2, 3),
            new WinningCombination(4, 5, 6),
            new WinningCombination(7, 8, 9),
            new WinningCombination(1, 4, 7),
            new WinningCombination(2, 5, 8),
            new WinningCombination(3, 6, 9),
            new WinningCombination(1, 5, 9),
            new WinningCombination(3, 5, 7)
        };

        public Player Player { get; set; } = new Player();
        public Player Opponent { get; set; } = new Player();
        public List<string> PlayersNames { get; set; } = new();
        public List<int> PlayersScores { get; set; } = new();
        public List<Square> Squares { get; protected set; }
        public MarkEnum NextTurn { get; set; } = MarkEnum.X;
        public MarkEnum? Winner { get; set; }

        public void FindWinner()
        {
            foreach (var w in WinningCombinations)
            {
                if (FindWinningLine(MarkEnum.X, w))
                    Winner = MarkEnum.X;
                if (FindWinningLine(MarkEnum.O, w))
                    Winner = MarkEnum.O;
            }
        }

        private bool FindWinningLine(MarkEnum mark, WinningCombination winningCombination)
        {
            return CheckSquareForMark(mark, winningCombination.Square1)
             && CheckSquareForMark(mark, winningCombination.Square2)
             && CheckSquareForMark(mark, winningCombination.Square3);
        }

        private bool CheckSquareForMark(MarkEnum mark, int square)
        {
            return Squares[square - 1].Mark == mark;
        }

        public void UpdateScores()
        {
            if (Winner.HasValue)
            {
                if (Winner == MarkEnum.O)
                {
                    if (Opponent.Mark == MarkEnum.O)
                        Opponent.Score += 1;
                    else Player.Score += 1;
                }
                else
                {
                    if (Opponent.Mark == MarkEnum.X)
                        Opponent.Score += 1;
                    else Player.Score += 1;
                }
            }
        }

        public void ResetGame()
        {
            Squares = new List<Square>();
            Winner = null;
            CreateTable();
        }

        private void CreateTable()
        {
            for (var tt = 1; tt <= 9; tt++)
                Squares.Add(new Square(tt));
        }
    }
}

