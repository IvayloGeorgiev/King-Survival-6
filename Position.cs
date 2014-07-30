namespace KingSurvivalGame
{
    using System;

    public class Position : ICloneable
    {
        private int x;
        private int y;

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

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

        public static Position operator +(Position a, Position b)
        {
            return new Position(a.X + b.X, a.Y + b.Y);
        }

        public object Clone()
        {
            return new Position(this.X, this.Y);
        }
    }
}
