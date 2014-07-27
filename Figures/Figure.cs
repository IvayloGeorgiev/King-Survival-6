namespace KingSurvivalGame.Figures
{
    using System;
    using System.Collections.Generic;
    using KingSurvivalGame.Interfaces;

    /// <summary>
    /// Abstract class representing information about the game figures.
    /// Each figure has initial position, representing symbol, can  move and be drawn.
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
        
        private int[] position;
        private Dictionary<string, int[]> movementCommands;

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

            protected set 
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

        /// <summary>
        /// Gets or sets the symbol for the figure
        /// </summary>
        public char Symbol { get; set; }

        /// <summary>
        /// Gets or sets the valid movement commands for the figure.
        /// </summary>
        public Dictionary<string, int[]> MovementCommands 
        {
            get
            {
                return this.movementCommands;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Movement commands should not be null.");
                }
                this.movementCommands = value;
            }
        }

        /// <summary>
        /// Checks the validity of Pawn commands
        /// </summary>
        /// <param name="subCommand">Command, that figure Pawn should implement</param>
        /// <returns>True or false, regarding the validity of the command</returns>
        public virtual bool CheckCommand(string command)
        {
            if (this.MovementCommands.ContainsKey(command))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Calculates new position of the figure.
        /// </summary>
        /// <param name="offset">Offset for the new position of the figure</param>        
        public virtual void Move(int[] offset)
        {            
            int[] newPosition = { this.Position[0] + offset[0], this.Position[1] + offset[1]};
            this.Position = newPosition;            
        }
    }
}
