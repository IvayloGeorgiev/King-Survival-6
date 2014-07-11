using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    public abstract class Figure 
    {
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
                //TODO check position
            }
        }

        public abstract bool CheckCommand(); //Maybe it shoudnt be here.        

    }
}
