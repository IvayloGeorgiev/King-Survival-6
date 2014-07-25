namespace KingSurvivalGame
{
    using System;

    /// <summary>
    /// Static class, representing simple factory for making figures
    /// </summary>
    public static class FigureSimpleFactory
    {
        /// <summary>
        /// Initializes a new instance of specific figure type
        /// </summary>
        /// <param name="figureType">specific figure type</param>
        /// <param name="initialPosition">Initial position of the figure</param>
        /// <param name="symbol">Character, which is a symbol for the figure</param>
        /// <returns>new instance of figure</returns>
        public static Figure GetFigure(FigureType figureType, int[] initialPosition, char symbol)
        {
            switch (figureType)
            {
                case FigureType.King:
                    return new King(initialPosition, symbol);
                case FigureType.Pawn:
                    return new Pawn(initialPosition, symbol);
                default:
                    throw new ArgumentException("Invalid figure type!");
            }
        }
    }
}
