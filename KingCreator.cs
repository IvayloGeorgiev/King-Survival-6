namespace KingSurvivalGame
{
    using System.Collections.Generic;

    public class KingCreator : FigureFactory
    {
        public override Figure CreateFigure(int[] initialPosition, char symbol)
        {
            var king = new King(initialPosition, symbol)
            {
                MovementCommands = new Dictionary<string,int[]> {
                    {(symbol + UpLeftCommand), UpLeftOffset}, 
                    {(symbol + UpRightCommand), UpRightOffset},
                    {(symbol + DownLeftCommand), DownLeftOffset},
                    {(symbol + DownRightCommand), DownRightOffset}
                }
            };

            return king;
        }
    }
}
