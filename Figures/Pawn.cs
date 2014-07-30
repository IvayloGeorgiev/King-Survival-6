namespace KingSurvivalGame.Figures
{       
    using KingSurvivalGame.Interfaces;

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
        public Pawn(Position initialPosition, char symbol)
            : base(initialPosition, symbol)
        {
        }              
    }
}
