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
                }
            };

            return pawn;
        }
    }
}
