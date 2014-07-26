namespace KingSurvivalGame
{
    using System.Collections.Generic;

    /// <summary>
    /// Class, representing the game figure Pawn
    /// </summary>
    public class Pawn : Figure, IMovable
    {
        /// <summary>
        /// Initializes a new instance of the Pawn class
        /// </summary>
        /// <param name="initialPosition">Initial position of the figure Pawn</param>
        /// <param name="symbol">Character, which is a symbol for the figure Pawn</param>
        public Pawn(int[] initialPosition, char symbol)
            : base(initialPosition, symbol)
        {
        }
        
        /// <summary>
        /// Checks the validity of Pawn commands
        /// </summary>
        /// <param name="subCommand">Command, that figure Pawn should implement</param>
        /// <returns>True or false, regarding the validity of the command</returns>
        public override bool CheckCommand(string command)
        {
            if (this.MovementCommands.ContainsKey(command))
            {
                return true;
            }

            return false;
        }
    }
}
