using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvivalGame
{
    public class King : Figure, IMovable
    {
        public King(int[] initialPosition) 
            : base(initialPosition)
        {
        }

        public override bool CheckCommand()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void Move(int[] offset)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
