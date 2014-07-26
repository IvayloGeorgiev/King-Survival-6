namespace KingSurvivalGame
{
    using System.Collections.Generic;

    public class PawnCreator : FigureFactory
    {
        public override Figure CreateFigure(int[] initialPosition, char symbol)
        {
            var pawn = new Pawn(initialPosition, symbol)
            {
                MovementCommands = new Dictionary<string, int[]> {                    
                    {(symbol + DownLeftCommand), DownLeftOffset},
                    {(symbol + DownRightCommand), DownRightOffset}
                },
                ValidSubCommands = new string[] { symbol + "DL", symbol + "DR" },
                Shape = new string[] { "  \u25E2\u25E3  ", " \u25E2\u2588\u2588\u25E3 ", " \u25E2\u2588\u2588\u25E3 ", " \u2588\u2588\u2588\u2588 ", symbol.ToString() }
            };

            return pawn;
        }
    }
}
