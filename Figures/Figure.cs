namespace KingSurvivalGame.Figures
{
    using System;
    using System.Collections.Generic;    

    /// <summary>
    /// Abstract class representing information about the game figures.
    /// Each figure has initial position, representing symbol, can  move and be drawn.
    /// </summary>
    public abstract class Figure : IMovable, IMoveSet
    {        
        private Position position;        
        private Dictionary<string, Position> movementCommands;

        /// <summary>
        /// Initializes a new instance of the Figure class
        /// </summary>
        /// <param name="initialPosition">Initial position of the figure</param>
        /// <param name="symbol">Character, which is a symbol for the figure</param>
        protected Figure(Position initialPosition, char symbol)
        {
            this.Position = initialPosition;
            this.Symbol = symbol;
        }

        /// <summary>
        /// Gets or sets the position of the figure
        /// </summary>
        public Position Position
        {
            get
            {
                return this.position;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Position should not be null.");
                }
                else if (value.X < 0 ||                    
                    value.X >= GlobalConstants.GameBoardSize ||
                    value.Y < 0 ||
                    value.Y >= GlobalConstants.GameBoardSize)
                {
                    throw new ArgumentException("Position must be within the bounds of the gameboard.");
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
        public Dictionary<string, Position> MovementCommands 
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
        public virtual void Move(Position offset)
        {            
            Position newPosition = this.Position + offset;
            this.Position = newPosition;            
        }
    }
}
