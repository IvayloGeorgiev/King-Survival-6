using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    public class Pawn : Figure, IMovable
    {
        //private readonly string[] validSubCommands = { "DL", "DR" };

        public Pawn(int[] initialPosition, char symbol)
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
