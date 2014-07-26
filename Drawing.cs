namespace KingSurvivalGame
{
    using System;    
    using System.Linq;

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
            this.Position = (int[]) figure.Position.Clone();
        }

        public int[] Position
        {
            get { return this.position; }
            protected set { this.position = value; }
        }

        public char Symbol
        {
            get { return this.symbol; }
            protected set { this.symbol = value; }
        }

        public string[] Shape
        {
            get { return this.shape; }
            protected set { this.shape = value; }
        }
    }
}
