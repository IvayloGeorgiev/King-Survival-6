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
        private string message;

        protected GameLogic Logic
        {
            get
            {
                return this.logic;
            }
            set
            {
                this.logic = value;
            }
        }        

        public string Message
        {
            get 
            { 
                return this.message; 
            }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentException("Turn message cannot be null.");
                }
                this.message = value;
            }
        }

        public abstract string GetEndMessage();
        public abstract bool CheckCommand(string input);
        public abstract string ExecuteCommand(string input);
        public abstract bool FiguresCanMove();
    }
}
