using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    public class King : Figure, IMovable
    {
        //private readonly string[] validSubCommands = { "UL", "UR", "DL", "DR" };

        public King(int[] initialPosition, char symbol) 
            : base(initialPosition, symbol)
        {
        }

        public override bool CheckCommand(string subCommand)
        {
            if (this.ValidSubCommands.Contains(subCommand))
            {
                return true;   
            }

            return false;
        }
    }
}
