namespace KingSurvivalGame.Figures
{        
    using KingSurvivalGame.Interfaces;

    /// <summary>
    /// Class, representing the game figure King
    /// </summary>
    public class King : Figure, IMovable
    {
        /// <summary>
        /// Initializes a new instance of the King class
        /// </summary>
        /// <param name="initialPosition">Initial position of the figure King</param>
        /// <param name="symbol">Character, which is a symbol for the figure King</param>
        public King(Position initialPosition, char symbol) 
            : base(initialPosition, symbol)
        {
        }        
    }
}
