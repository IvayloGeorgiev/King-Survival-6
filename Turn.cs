using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    public abstract class Turn
    {
        protected GameLogic logic;

        protected GameLogic Logic
        {
            get
            {
                return logic;
            }
            set
            {
                this.Logic = value;
            }
        }

        public abstract bool ProcessInput(string input);
        public abstract void MoveFigures();
    }
}
