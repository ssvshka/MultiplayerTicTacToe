namespace MultiplayerTicTacToe.Models
{
    public class WinningCombination
    {
        public int Square1 { get; }

        public int Square2 { get; }

        public int Square3 { get; }

        public WinningCombination(int square1, int square2, int square3)
        {
            Square1 = square1;
            Square2 = square2;
            Square3 = square3;
        }
    }
}
