﻿namespace KingSurvivalGame.Figures
{
    using System.Collections.Generic;

    /// <summary>
    /// Used to create figures of type king.
    /// </summary>
    public class KingCreator : FigureFactory
    {
        /// <summary>
        /// Implementation of the factory that deals with the creation of a new king figure, by a given symbol and position for it.
        /// </summary>
        /// <param name="initialPosition">Initial position of the king provided as an int array of size 2.</param>
        /// <param name="symbol">The symbol used to identify the king.</param>
        /// <returns>A new king figure at the given position, with the given symbol, with all commands related to figure movement.</returns>
        public override Figure CreateFigure(Position initialPosition, char symbol)
        {
            var king = new King(initialPosition, symbol)
            {
                MovementCommands = new Dictionary<string, Position> 
                { 
                    { (symbol + UpLeftCommand), UpLeftOffset },
                    { (symbol + UpRightCommand), UpRightOffset },
                    { (symbol + DownLeftCommand), DownLeftOffset },
                    { (symbol + DownRightCommand), DownRightOffset }
                }
            };

            return king;
        }
    }
}
