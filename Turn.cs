using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    public abstract class Turn
    {
        private GameLogic logic;

        protected GameLogic Logic
        {
            get
            {
                return this.logic;
            }
            set
            {
                this.Logic = value;
            }
        }

        public abstract bool CheckCommand(string input);
        public abstract string ExecuteCommand(string input);        
    }
}
