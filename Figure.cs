using System;

namespace KingSurvivalGame
{
    /// <summary>
    /// Abstract class representing information about the game figures.
    /// Each figure has initial position, valid commands and can move.
    /// </summary>
    public abstract class Figure : IMovable 
    {
        /// <summary>
        /// Constant representing the minimum value of the row, where the figure is positioned.
        /// </summary>
        private const int MinRow = 0;

        /// <summary>
        /// Constant representing the maximum value of the row, where the figure is positioned.
        /// </summary>
        private const int MaxRow = 7;

        /// <summary>
        /// Constant representing the minimum value of the column, where the figure is positioned.
        /// </summary>
        private const int MinCol = 0;

        /// <summary>
        /// Constant representing the maximum value of the column, where the figure is positioned.
        /// </summary>
        private const int MaxCol = 7;

        /// <summary>
        /// Field representing the position of the figure
        /// </summary>
        private int[] position;

        /// <summary>
        /// Initializes a new instance of the Figure class
        /// </summary>
        /// <param name="initialPosition">Initial position of the figure</param>
        /// <param name="symbol">Character, which is a symbol for the figure</param>
        protected Figure(int[] initialPosition, char symbol)
        {
            this.Position = initialPosition;
            this.Symbol = symbol;
        }

        /// <summary>
        /// Gets or sets the position of the figure
        /// </summary>
        public int[] Position 
        { 
            get
            {
                return this.position;
            }

            set 
            {
                if (value[0] < MinRow || value[0] > MaxRow)
                {
                    throw new ArgumentOutOfRangeException("Initial row is out of valid range!");    
                }

                if (value[1] < MinCol || value[1] > MaxCol)
                {
                    throw new ArgumentOutOfRangeException("Initial column is out of valid range!");   
                }

                this.position = value;
            }
        }
        public char Symbol { get; set; }

        /// <summary>
        /// Checks the validity of figure commands
        /// </summary>
        /// <param name="subCommand">Command, that specific figure should implement</param>
        /// <returns>True or false, regarding the validity of the command</returns>
        public abstract bool CheckCommand(string subCommand); 

        /// <summary>
        /// Calculates new position of the figure.
        /// </summary>
        /// <param name="offset">Offset for the new position of the figure</param>
        /// <returns>new position of the figure</returns>
        public int[] Move(int[] offset)
        {
            int[] newPosition = { this.Position[0] + offset[0], this.Position[1] + offset[1] };
            return newPosition;
        }
    }
}
