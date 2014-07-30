namespace KingSurvivalGame.Display
{
    using System;        

    using KingSurvivalGame.Figures;
    using KingSurvivalGame.Interfaces;

    public abstract class Drawing : IDrawable
    {
        /// <summary>
        /// Field representing the position of the figure.
        /// </summary>
        private int[] position;

        /// <summary>
        /// Field representing the symbol related to the figure.
        /// </summary>
        private char symbol;

        /// <summary>
        /// Field that holds the string array that contains the shape of the figure.
        /// </summary>
        private string[] shape;

        public Drawing(Figure figure)
        {
            this.Symbol = figure.Symbol;
            this.Position = (int[])figure.Position.Clone();
        }

        /// <summary>
        /// Position of the drawing objecst as an integer array of size two.
        /// </summary>
        public int[] Position
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
                else if (value.Length != 2)
                {
                    throw new ArgumentException("Position cannot have more then two values.");
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
