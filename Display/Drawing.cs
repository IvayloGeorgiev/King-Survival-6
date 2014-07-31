namespace KingSurvivalGame.Display
{
    using System;        

    using KingSurvivalGame.Figures;
    using KingSurvivalGame.Interfaces;

    /// <summary>
    /// A drawing object has a coordinate position, character symbol representing it and a shape associated with the drawing.
    /// </summary>
    public abstract class Drawing : IDrawable
    {
        /// <summary>
        /// Field representing the position of the drawing.
        /// </summary>
        private Position position;

        /// <summary>
        /// Field representing the symbol related to the drawing.
        /// </summary>
        private char symbol;

        /// <summary>
        /// Field that holds the string array that contains the shape of the drawing.
        /// </summary>
        private string[] shape;

        /// <summary>
        /// Instantiates a drawing type object at the same position and with the same symbol as those of the figure
        /// </summary>
        /// <param name="figure"></param>
        public Drawing(Figure figure)
        {
            this.Symbol = figure.Symbol;
            this.Position = (Position)figure.Position.Clone();
        }

        /// <summary>
        /// Position of the drawing object as an integer array of size two.
        /// </summary>
        public Position Position
        {
            get 
            { 
                return this.position; 
            }

            protected set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Position array should not be null.");
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
        /// Symbol identifier of the drawing object.
        /// </summary>
        public char Symbol
        {
            get 
            { 
                return this.symbol; 
            }

            protected set 
            { 
                this.symbol = value; 
            }
        }

        /// <summary>
        /// The shape, as an array of strings, to be displayed when visualizing the drawing. 
        /// </summary>
        public string[] Shape
        {
            get 
            { 
                return this.shape; 
            }

            protected set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Shape should not be null.");
                }

                this.shape = value; 
            }
        }
    }
}
