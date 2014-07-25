﻿namespace KingSurvivalGame
{
    using System.Linq;

    /// <summary>
    /// Class, representing the game figure King
    /// </summary>
    public class King : Figure, IMovable, IDrawable
    {
        /// <summary>
        /// Initializes a new instance of the King class
        /// </summary>
        /// <param name="initialPosition">Initial position of the figure King</param>
        /// <param name="symbol">Character, which is a symbol for the figure King</param>
        public King(int[] initialPosition, char symbol) 
            : base(initialPosition, symbol)
        {
        }

        /// <summary>
        /// Checks the validity of King commands
        /// </summary>
        /// <param name="subCommand">Command, that figure King should implement</param>
        /// <returns>True or false, regarding the validity of the command</returns>
        public override bool CheckCommand(string subCommand)
        {
            if (this.ValidSubCommands.Contains(subCommand))
            {
                return true;   
            }

            return false;
        }
    }
}
