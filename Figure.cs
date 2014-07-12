using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    public abstract class Figure : IMovable 
    {
        private const int MinRow = 0;
        private const int MaxRow = 7;
        private const int MinCol = 0;
        private const int MaxCol = 7;

        private int[] position;

        protected Figure(int[] initialPosition)
        {
            this.Position = initialPosition;
        }

        protected int[] Position 
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

        public abstract bool CheckCommand(string subCommand); //Maybe it shoudnt be here.  

        public int[] Move(int[] offset)
        {
            int[] newPosition = { this.Position[0] + offset[0], this.Position[1] + offset[1] };
            return newPosition;
        }
    }
}
