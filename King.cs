using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    public class King : Figure, IMovable
    {
        private readonly string[] validSubCommands = { "UL", "UR", "DL", "DR" };

        public King(int[] initialPosition) 
            : base(initialPosition)
        {
        }

        public override bool CheckCommand(string subCommand)
        {
            if (validSubCommands.Contains(subCommand))
            {
                return true;   
            }

            return false;
        }

        public void Move(int[] offset)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
