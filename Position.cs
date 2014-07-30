namespace KingSurvivalGame
{
    using System;

    public class Position : ICloneable
    {
        private int x;
        private int y;

        /// <summary>
        /// Instantiates a position at the given x and y coordinates.
        /// </summary>
        /// <param name="x">The horizontal position</param>
        /// <param name="y">The vertical position</param>
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets or sets the horizontal position.
        /// </summary>
        public int X
        {
            get
            {
                return this.x;
            }

            set
            {                
                this.x = value;
            }
        }

        /// <summary>
        /// Gets or set the vertical position.
        /// </summary>
        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        /// <summary>
        /// Adds any two given positions together and returns a new position object.
        /// </summary>
        /// <param name="a">The first position</param>
        /// <param name="b">The second position</param>
        /// <returns>The sum of both positions</returns>
        public static Position operator +(Position a, Position b)
        {
            return new Position(a.X + b.X, a.Y + b.Y);
        }

        /// <summary>
        /// Checks if a given object is of type position and if so, whether its x and y properties are the same as the current position.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <returns>True if the object is of type position and has the same coordinates, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            
            Position position = obj as Position;
            if (position == null)
            {
                return false;
            }
            
            return (this.x == position.x) && (this.y == position.y);
        }

        /// <summary>
        /// Clones the given position object.
        /// </summary>
        /// <returns>A new position that has the same x and y coordinates.</returns>
        public object Clone()
        {
            return new Position(this.X, this.Y);
        }      
    }
}
