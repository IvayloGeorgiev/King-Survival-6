using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    public abstract class Figure 
    {
        protected int[] Position { get; set; }

        public abstract bool CheckCommand(); //Maybe it shoudnt be here.        

    }
}
