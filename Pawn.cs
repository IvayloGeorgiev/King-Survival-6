using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    public class Pawn : Figure, IMovable
    {
        private readonly string[] validSubCommands = { "DL", "DR" };
        public Pawn(int[] initialPosition)
            : base(initialPosition)
        {
        }

        public void Move(int[] offset)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
        
        public override bool CheckCommand(string subCommand)
        {
            if (validSubCommands.Contains(subCommand))
            {
                return true;
            }

            return false;
        }
    }
}
