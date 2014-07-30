namespace KingSurvivalGame.Figures
{
    using System.Collections.Generic;

    public class PawnCreator : FigureFactory
    {
        /// <summary>
        /// Implementation of the figure factory that deals with the creation of a new pawn figure, by a given symbol and position for it.
        /// </summary>
        /// <param name="initialPosition">Initial position of the king provided as an int array of size 2.</param>
        /// <param name="symbol">The symbol used to identify the pawn.</param>
        /// <returns>A new pawn figure at the given position, with the given symbol, with all commands related to figure movement.</returns>
        public override Figure CreateFigure(int[] initialPosition, char symbol)
        {
            var pawn = new Pawn(initialPosition, symbol)
            {
                MovementCommands = new Dictionary<string, int[]> 
                {                    
                    { (symbol + DownLeftCommand), DownLeftOffset },
                    { (symbol + DownRightCommand), DownRightOffset }
                }
            };

            return pawn;
        }
    }
}
